﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CrossCutting.Message.Validation {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class GenericValidationMessages {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal GenericValidationMessages() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("CrossCutting.Message.Validation.GenericValidationMessages", typeof(GenericValidationMessages).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Campo {0} atual não pode ser vazio..
        /// </summary>
        public static string CampoNaoPodeSerVazio {
            get {
                return ResourceManager.GetString("CampoNaoPodeSerVazio", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Campo {0} deve ter no máximo {1} caracteres..
        /// </summary>
        public static string CaracteresMaximo {
            get {
                return ResourceManager.GetString("CaracteresMaximo", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Campo {0} deve ter no mínimo {1} caracteres.
        /// </summary>
        public static string CaracteresMinimo {
            get {
                return ResourceManager.GetString("CaracteresMinimo", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Email já cadastrado.
        /// </summary>
        public static string EmailCadastrado {
            get {
                return ResourceManager.GetString("EmailCadastrado", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Email Invalido.
        /// </summary>
        public static string EmailInvalido {
            get {
                return ResourceManager.GetString("EmailInvalido", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0}  não encontrado..
        /// </summary>
        public static string NaoEncontrado {
            get {
                return ResourceManager.GetString("NaoEncontrado", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Os requisitos de Email não foram atendidos..
        /// </summary>
        public static string RequisitosEmail {
            get {
                return ResourceManager.GetString("RequisitosEmail", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Nova senha não pode ser igual a anterior..
        /// </summary>
        public static string SenhaNaoPodeSerIgual {
            get {
                return ResourceManager.GetString("SenhaNaoPodeSerIgual", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Valor mínimo é {0}.
        /// </summary>
        public static string ValorMinimo {
            get {
                return ResourceManager.GetString("ValorMinimo", resourceCulture);
            }
        }
    }
}
