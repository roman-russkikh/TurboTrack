/*
 * Openfort API
 *
 * Complete Openfort API references and guides can be found at: https://openfort.xyz/docs
 *
 * The version of the OpenAPI document: 1.0.0
 * Contact: founders@openfort.xyz
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */


using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using OpenAPIDateConverter = Openfort.Client.OpenAPIDateConverter;

namespace Openfort.Model
{
    /// <summary>
    /// Defines DataAccountTypes
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum DataAccountTypes
    {
        /// <summary>
        /// Enum Upgradeable for value: Upgradeable
        /// </summary>
        [EnumMember(Value = "Upgradeable")]
        Upgradeable = 1,

        /// <summary>
        /// Enum Managed for value: Managed
        /// </summary>
        [EnumMember(Value = "Managed")]
        Managed = 2,

        /// <summary>
        /// Enum ERC6551 for value: ERC6551
        /// </summary>
        [EnumMember(Value = "ERC6551")]
        ERC6551 = 3,

        /// <summary>
        /// Enum Recoverable for value: Recoverable
        /// </summary>
        [EnumMember(Value = "Recoverable")]
        Recoverable = 4

    }

}
