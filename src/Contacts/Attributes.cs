using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Contacts
{
    /// <summary>
    /// Default contact attributes keys <br />
    /// Reserved keys ...
    /// </summary>
    public struct Attributes
    {
        /// <summary>
        /// Key for title attribute
        /// </summary>
        public const string Title = "titulo";

        /// <summary>
        /// Key for (marker|tag) attribute
        /// </summary>
        public const string Marker = "marcador";

        /// <summary>
        /// Key for group id attribute
        /// </summary>
        public const string GroupId = "idgrupo";

        /// <summary>
        /// Key for contact owner id attribute
        /// </summary>
        public const string OwnerId = "idproprietario";

        /// <summary>
        /// Key for document of id, CPF or CNPJ
        /// </summary>
        public const string Document = "cadastro";

        /// <summary>
        ///     Marks the entire object for non-removal, its avoid the contact to be deleted 
        /// </summary>
        public const string Important = "important";
    }
}
