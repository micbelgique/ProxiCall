﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProxiCall.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class strings {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal strings() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("ProxiCall.Properties.strings", typeof(strings).Assembly);
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
        ///   Looks up a localized string similar to Nous transférons votre appel..
        /// </summary>
        public static string callForwardingConfirmed {
            get {
                return ResourceManager.GetString("callForwardingConfirmed", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Souhaitez vous être mis en contact ?.
        /// </summary>
        public static string forwardCallPrompt {
            get {
                return ResourceManager.GetString("forwardCallPrompt", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Merci d&apos;avoir utiliser ProxiCall. Bonne journée..
        /// </summary>
        public static string goodbye {
            get {
                return ResourceManager.GetString("goodbye", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Le numéro de.
        /// </summary>
        public static string phoneNumberOf_1 {
            get {
                return ResourceManager.GetString("phoneNumberOf_1", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to est le.
        /// </summary>
        public static string phoneNumberOf_2 {
            get {
                return ResourceManager.GetString("phoneNumberOf_2", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Quelle est la personne que vous recherchez ?.
        /// </summary>
        public static string querySearchPerson {
            get {
                return ResourceManager.GetString("querySearchPerson", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to n&apos;a pas été trouvé. Souhaitez-vous réessayer?.
        /// </summary>
        public static string retryNumberSearchPrompt {
            get {
                return ResourceManager.GetString("retryNumberSearchPrompt", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Veuillez répondre par &apos;Oui&apos; ou  &apos;Non&apos; pour confirmer..
        /// </summary>
        public static string retryPrompt {
            get {
                return ResourceManager.GetString("retryPrompt", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Bienvenue sur ProxiCall..
        /// </summary>
        public static string welcome {
            get {
                return ResourceManager.GetString("welcome", resourceCulture);
            }
        }
    }
}
