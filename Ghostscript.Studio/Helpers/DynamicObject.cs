#region This file is part of Ghostscript.Studio application
//
// DynamicObject.cs
//
// Author: Josip Habjan (habjan@gmail.com, http://www.linkedin.com/in/habjan) 
// Copyright (c) 2013 - 2023 Josip Habjan. All rights reserved.
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
//
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Reflection.Emit;
using System.ComponentModel;
using System.Threading;

namespace Ghostscript.Studio.Helpers
{
    public class DynamicObject
    {
        #region Static private variables

        private static readonly ConstructorInfo _ci_displayName = typeof(DisplayNameAttribute).GetConstructor(new[] { typeof(string) });
        private static readonly ConstructorInfo _ci_description = typeof(DescriptionAttribute).GetConstructor(new[] { typeof(string) });
        private static readonly ConstructorInfo _ci_typeConverter = typeof(TypeConverterAttribute).GetConstructor(new[] { typeof(Type) });

        #endregion

        #region Private variables

        private AssemblyBuilder _assemblyBuilder = null;
        private ModuleBuilder _moduleBuilder = null;
        private TypeBuilder _typeBuilder = null;
        private Type _objectType = null;
        private object _objectInstance = null;

        #endregion

        #region Constructor

        public DynamicObject()
        {
            _assemblyBuilder = Thread.GetDomain().DefineDynamicAssembly(new AssemblyName(Guid.NewGuid().ToString("N")), AssemblyBuilderAccess.Run);
            _moduleBuilder = _assemblyBuilder.DefineDynamicModule(Guid.NewGuid().ToString("N"));
            _typeBuilder = _moduleBuilder.DefineType(Guid.NewGuid().ToString("N"));
        }

        #endregion

        #region AddProperty

        private void AddProperty(TypeBuilder typeBuilder, string name, Type type, Type typeConverterType, string displayName, string displayDescription)
        {
            FieldBuilder field = typeBuilder.DefineField("m" + name, type, FieldAttributes.Private);
            PropertyBuilder propertyBuilder = typeBuilder.DefineProperty(name, PropertyAttributes.None, type, null);

            MethodAttributes getSetAttr = MethodAttributes.Public | MethodAttributes.HideBySig | MethodAttributes.SpecialName | MethodAttributes.Virtual;

            MethodBuilder getter = typeBuilder.DefineMethod("get_" + name, getSetAttr, type, Type.EmptyTypes);

            ILGenerator getIL = getter.GetILGenerator();
            getIL.Emit(OpCodes.Ldarg_0);
            getIL.Emit(OpCodes.Ldfld, field);
            getIL.Emit(OpCodes.Ret);

            MethodBuilder setter = typeBuilder.DefineMethod("set_" + name, getSetAttr, null, new Type[] { type });

            ILGenerator setIL = setter.GetILGenerator();
            setIL.Emit(OpCodes.Ldarg_0);
            setIL.Emit(OpCodes.Ldarg_1);
            setIL.Emit(OpCodes.Stfld, field);
            setIL.Emit(OpCodes.Ret);

            propertyBuilder.SetCustomAttribute(new CustomAttributeBuilder(_ci_displayName, new object[] { displayName }));
            propertyBuilder.SetCustomAttribute(new CustomAttributeBuilder(_ci_description, new object[] { displayDescription }));

            if (typeConverterType != null)
            {
                propertyBuilder.SetCustomAttribute(new CustomAttributeBuilder(_ci_typeConverter, new object[] { typeConverterType }));
            }

            propertyBuilder.SetGetMethod(getter);
            propertyBuilder.SetSetMethod(setter);
        }

        #endregion

        #region CreateInstance

        public void CreateInstance()
        {
            _objectType = _typeBuilder.CreateType();
            _objectInstance = Activator.CreateInstance(_objectType);
        }

        #endregion

        #region Instance

        public object Instance
        {
            get { return _objectInstance; }
        }

        #endregion
    }
}
