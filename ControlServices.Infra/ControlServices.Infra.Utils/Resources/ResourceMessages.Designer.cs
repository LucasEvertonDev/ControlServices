﻿//------------------------------------------------------------------------------
// <auto-generated>
//     O código foi gerado por uma ferramenta.
//     Versão de Tempo de Execução:4.0.30319.42000
//
//     As alterações ao arquivo poderão causar comportamento incorreto e serão perdidas se
//     o código for gerado novamente.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ControlServices.Infra.Utils.Resources {
    using System;
    
    
    /// <summary>
    ///   Uma classe de recurso de tipo de alta segurança, para pesquisar cadeias de caracteres localizadas etc.
    /// </summary>
    // Essa classe foi gerada automaticamente pela classe StronglyTypedResourceBuilder
    // através de uma ferramenta como ResGen ou Visual Studio.
    // Para adicionar ou remover um associado, edite o arquivo .ResX e execute ResGen novamente
    // com a opção /str, ou recrie o projeto do VS.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class ResourceMessages {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal ResourceMessages() {
        }
        
        /// <summary>
        ///   Retorna a instância de ResourceManager armazenada em cache usada por essa classe.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("ControlServices.Infra.Utils.Resources.ResourceMessages", typeof(ResourceMessages).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Substitui a propriedade CurrentUICulture do thread atual para todas as
        ///   pesquisas de recursos que usam essa classe de recurso de tipo de alta segurança.
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
        ///   Consulta uma cadeia de caracteres localizada semelhante a Já existe um usuário cadastrado para o email informado.
        /// </summary>
        public static string EmailAlreadyRegistered {
            get {
                return ResourceManager.GetString("EmailAlreadyRegistered", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a Email é  obrigatório.
        /// </summary>
        public static string EmailRequired {
            get {
                return ResourceManager.GetString("EmailRequired", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a Já existe um usuário cadastrado para o login informado.
        /// </summary>
        public static string LoginAlreadRegistered {
            get {
                return ResourceManager.GetString("LoginAlreadRegistered", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a A Senha deve conter no mínimo seis caracteres.
        /// </summary>
        public static string PasswordMinLenghtSixCharacters {
            get {
                return ResourceManager.GetString("PasswordMinLenghtSixCharacters", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a Senha é obrigatória.
        /// </summary>
        public static string PasswordRequired {
            get {
                return ResourceManager.GetString("PasswordRequired", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a Erro desconhecido.
        /// </summary>
        public static string Unknownerror {
            get {
                return ResourceManager.GetString("Unknownerror", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a Email inválido.
        /// </summary>
        public static string UserEmailInvalid {
            get {
                return ResourceManager.GetString("UserEmailInvalid", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a Login inválido.
        /// </summary>
        public static string UserNameInvalid {
            get {
                return ResourceManager.GetString("UserNameInvalid", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a O Login deve conter no mínimo cinco caracteres.
        /// </summary>
        public static string UserNameMinLenght {
            get {
                return ResourceManager.GetString("UserNameMinLenght", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a Login é obrigatório.
        /// </summary>
        public static string UserNameRequired {
            get {
                return ResourceManager.GetString("UserNameRequired", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a Login e senha inválidos.
        /// </summary>
        public static string UserOrPasswordInvalid {
            get {
                return ResourceManager.GetString("UserOrPasswordInvalid", resourceCulture);
            }
        }
    }
}
