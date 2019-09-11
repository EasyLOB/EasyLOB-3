using System;
using System.IO;
using System.Text.RegularExpressions;

namespace EasyLOB.Library
{
    public enum Archetypes
    {
        Application,
        Persistence
    }

    public enum Cultures
    {
        en_US, // English
        pt_BR // Brazilian Portuguese
    }

    public static class CodeSmithHelper
    {

        #region Properties

        // Acronyms that should not be renamed in Classes, Objects and Properties Names
        // Array.IndexOf(Acronyms, name) < 0
        private static string[] Acronyms
        {
            get
            {
                return new string[]
                {
                    // en-US
                    "ERP",          // Enterprise Resource Planning
                    "CRM",          // Customer Relationship Management
                    "ZIP",          // Zone Improvement Plan
                    // pt-BR
                    "CEP",          // Código de Endereçamento Postal
                    "CFOP",         // Código Fiscal de Operação e Prestação
                    "CNPJ",         // Cadastro Nacional de Pessoas Jurídicas    
                    "CPF",          // Cadastro de Pessoas Físicas
                    "CST",          // Código de Situação Tributária
                    "DDD",          // Discagem Direta a Distância
                    "ICMS",         // Imposto sobre Circulação de Mercadorias e Serviços
                    "ICMSST",       // ICMS Substituição Tributária
                    "IE",           // Inscrição Estadual
                    "IPI",          // Imposto de Produtos Industralizados
                    "IR",           // Imposto de Renda
                    "IRRF",         // Imposto de Renda Retido na Fonte
                    "ISS",          // Imposto sobre Serviços
                    "MVAICMSST",    // MVA ICMS Substituição Tributária
                    "NCM",          // Nomeclatura Comum do Mercosul
                    "NF",           // Nota Fiscal
                    "Pais",         // País
                    "RG",           // Registro Geral
                    "UF",           // Unidade da Federação
                    "CNPJCPF",      // CNPJ + CPF
                    "IERG",         // IE + RG
                    //
                    "AZ"
                };
            }
        }

        #endregion

        #region Methods
        public static void CreateDirectory(string directory)
        {
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }

        public static bool IsNullOrEmpty(string s) // 2.6
        {
            return (s == null || s.Trim() == "");
        }

        public static string Plural(string s, Cultures culture)
        {
            if (culture == Cultures.pt_BR)
            {
                return Plural_pt_BR(s);
            }
            else
            {
                return Plural_en_US(s);
            }
        }

        public static string Plural_en_US(string s)
        {
            string result = "";

            s = s.Trim();

            if (s.EndsWith("ss"))
            {
                result = System.Text.RegularExpressions.Regex.Replace(s, "ss$", "sses"); // ss => sses
            }
            else if (s.EndsWith("s"))
            {
                result = s;
            }
            else if (s.EndsWith("y"))
            {
                result = System.Text.RegularExpressions.Regex.Replace(s, "y$", "ies"); // y => ies
            }
            else
            {
                result = s + "s"; // ? => s
            }

            return result;
        }

        public static string Plural_pt_BR(string s)
        {
            string result = "";

            s = s.Trim();

            if (s.EndsWith("ao"))
            {
                result = System.Text.RegularExpressions.Regex.Replace(s, "ao$", "oes"); // ao => oes
            }
            else if (s.EndsWith("l"))
            {
                result = System.Text.RegularExpressions.Regex.Replace(s, "l$", "is"); // l => is
            }
            else if (s.EndsWith("m"))
            {
                result = System.Text.RegularExpressions.Regex.Replace(s, "m$", "ns"); // m => ns
            }
            else if (s.EndsWith("r"))
            {
                result = System.Text.RegularExpressions.Regex.Replace(s, "r$", "res"); // r => res
            }
            else if (s.EndsWith("s"))
            {
                result = System.Text.RegularExpressions.Regex.Replace(s, "s$", "ses"); // s => ses
            }
            else
            {
                result = s + "s";
            }

            return result;
        }

        public static string Singular(string s, Cultures culture)
        {
            if (Array.IndexOf(Acronyms, s) >= 0) // Is an Acronym
            {
                return s;
            }
            else if (culture == Cultures.pt_BR)
            {
                return Singular_pt_BR(s);
            }
            else
            {
                return Singular_en_US(s);
            }
        }

        public static string Singular_en_US(string s)
        {
            string result = "";

            s = s.Trim();

            if (s.EndsWith("ss"))
            {
                result = s;
            }
            else if (s.EndsWith("ies"))
            {
                result = System.Text.RegularExpressions.Regex.Replace(s, "ies$", "y"); // y => ies
            }
            else if (s.EndsWith("sses"))
            {
                result = System.Text.RegularExpressions.Regex.Replace(s, "sses$", "ss"); // ss => sses
            }
            else if (s.EndsWith("s"))
            {
                result = System.Text.RegularExpressions.Regex.Replace(s, "s$", ""); // ? => s
            }
            else
            {
                result = s;
            }

            return result;
        }

        public static string Singular_pt_BR(string s)
        {
            string result = "";

            s = s.Trim();

            if (s.EndsWith("oes"))
            {
                result = System.Text.RegularExpressions.Regex.Replace(s, "oes$", "ao"); // ao => oes
            }
            else if (s.EndsWith("is") && s.Length > 4)
            {
                result = System.Text.RegularExpressions.Regex.Replace(s, "is$", "l"); // l => is
            }
            else if (s.EndsWith("ns"))
            {
                result = System.Text.RegularExpressions.Regex.Replace(s, "ns$", "m"); // m => ns
            }
            else if (s.EndsWith("res") && s.Length > 5)
            {
                result = System.Text.RegularExpressions.Regex.Replace(s, "res$", "r"); // r => res
            }
            else if (s.EndsWith("s") && s.Length > 4)
            {
                result = System.Text.RegularExpressions.Regex.Replace(s, "s$", ""); // ? => s
            }
            else
            {
                result = s;
            }

            return result;
        }

        public static string StringSplitPascalCase(string s)
        {
            Regex regex = new Regex("(?<=[a-z])(?<x>[A-Z|0-9|#])|(?<=.)(?<x>[A-Z|0-9|#])(?=[a-z])");

            return regex.Replace(s, " ${x}").Replace("_", " "); // "_" => " " ???
        }

        public static string StringToLowerFirstLetter(string s)
        {
            if (s.Length > 1)
            {
                return Char.ToLower(s[0]) + s.Substring(1); // 2.6
                //return Char.ToLowerInvariant(s[0]) + s.Substring(1); // 2.6
            }
            else
            {
                return s.ToLower();
            }
        }

        public static string StringToUpperFirstLetter(string s)
        {
            if (s.Length > 1)
            {
                return Char.ToUpper(s[0]) + s.Substring(1);
                //return Char.ToUpperInvariant(s[0]) + s.Substring(1); // 2.6
            }
            else
            {
                return s.ToUpper();
            }
        }

        #endregion Methods
    }
}
