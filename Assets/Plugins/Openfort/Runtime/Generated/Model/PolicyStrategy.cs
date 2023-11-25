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
using System.Reflection;

namespace Openfort.Model
{
    /// <summary>
    /// PolicyStrategy
    /// </summary>
    [JsonConverter(typeof(PolicyStrategyJsonConverter))]
    [DataContract(Name = "PolicyStrategy")]
    public partial class PolicyStrategy : AbstractOpenAPISchema, IEquatable<PolicyStrategy>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PolicyStrategy" /> class
        /// with the <see cref="PayForUserPolicyStrategy" /> class
        /// </summary>
        /// <param name="actualInstance">An instance of PayForUserPolicyStrategy.</param>
        public PolicyStrategy(PayForUserPolicyStrategy actualInstance)
        {
            this.IsNullable = false;
            this.SchemaType= "anyOf";
            this.ActualInstance = actualInstance ?? throw new ArgumentException("Invalid instance found. Must not be null.");
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PolicyStrategy" /> class
        /// with the <see cref="ChargeCustomTokenPolicyStrategy" /> class
        /// </summary>
        /// <param name="actualInstance">An instance of ChargeCustomTokenPolicyStrategy.</param>
        public PolicyStrategy(ChargeCustomTokenPolicyStrategy actualInstance)
        {
            this.IsNullable = false;
            this.SchemaType= "anyOf";
            this.ActualInstance = actualInstance ?? throw new ArgumentException("Invalid instance found. Must not be null.");
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PolicyStrategy" /> class
        /// with the <see cref="FixedRateTokenPolicyStrategy" /> class
        /// </summary>
        /// <param name="actualInstance">An instance of FixedRateTokenPolicyStrategy.</param>
        public PolicyStrategy(FixedRateTokenPolicyStrategy actualInstance)
        {
            this.IsNullable = false;
            this.SchemaType= "anyOf";
            this.ActualInstance = actualInstance ?? throw new ArgumentException("Invalid instance found. Must not be null.");
        }


        private Object _actualInstance;

        /// <summary>
        /// Gets or Sets ActualInstance
        /// </summary>
        public override Object ActualInstance
        {
            get
            {
                return _actualInstance;
            }
            set
            {
                if (value.GetType() == typeof(ChargeCustomTokenPolicyStrategy))
                {
                    this._actualInstance = value;
                }
                else if (value.GetType() == typeof(FixedRateTokenPolicyStrategy))
                {
                    this._actualInstance = value;
                }
                else if (value.GetType() == typeof(PayForUserPolicyStrategy))
                {
                    this._actualInstance = value;
                }
                else
                {
                    throw new ArgumentException("Invalid instance found. Must be the following types: ChargeCustomTokenPolicyStrategy, FixedRateTokenPolicyStrategy, PayForUserPolicyStrategy");
                }
            }
        }

        /// <summary>
        /// Get the actual instance of `PayForUserPolicyStrategy`. If the actual instance is not `PayForUserPolicyStrategy`,
        /// the InvalidClassException will be thrown
        /// </summary>
        /// <returns>An instance of PayForUserPolicyStrategy</returns>
        public PayForUserPolicyStrategy GetPayForUserPolicyStrategy()
        {
            return (PayForUserPolicyStrategy)this.ActualInstance;
        }

        /// <summary>
        /// Get the actual instance of `ChargeCustomTokenPolicyStrategy`. If the actual instance is not `ChargeCustomTokenPolicyStrategy`,
        /// the InvalidClassException will be thrown
        /// </summary>
        /// <returns>An instance of ChargeCustomTokenPolicyStrategy</returns>
        public ChargeCustomTokenPolicyStrategy GetChargeCustomTokenPolicyStrategy()
        {
            return (ChargeCustomTokenPolicyStrategy)this.ActualInstance;
        }

        /// <summary>
        /// Get the actual instance of `FixedRateTokenPolicyStrategy`. If the actual instance is not `FixedRateTokenPolicyStrategy`,
        /// the InvalidClassException will be thrown
        /// </summary>
        /// <returns>An instance of FixedRateTokenPolicyStrategy</returns>
        public FixedRateTokenPolicyStrategy GetFixedRateTokenPolicyStrategy()
        {
            return (FixedRateTokenPolicyStrategy)this.ActualInstance;
        }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class PolicyStrategy {\n");
            sb.Append("  ActualInstance: ").Append(this.ActualInstance).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public override string ToJson()
        {
            return JsonConvert.SerializeObject(this.ActualInstance, PolicyStrategy.SerializerSettings);
        }

        /// <summary>
        /// Converts the JSON string into an instance of PolicyStrategy
        /// </summary>
        /// <param name="jsonString">JSON string</param>
        /// <returns>An instance of PolicyStrategy</returns>
        public static PolicyStrategy FromJson(string jsonString)
        {
            PolicyStrategy newPolicyStrategy = null;

            if (string.IsNullOrEmpty(jsonString))
            {
                return newPolicyStrategy;
            }

            try
            {
                newPolicyStrategy = new PolicyStrategy(JsonConvert.DeserializeObject<ChargeCustomTokenPolicyStrategy>(jsonString, PolicyStrategy.SerializerSettings));
                // deserialization is considered successful at this point if no exception has been thrown.
                return newPolicyStrategy;
            }
            catch (Exception exception)
            {
                // deserialization failed, try the next one
                System.Diagnostics.Debug.WriteLine(string.Format("Failed to deserialize `{0}` into ChargeCustomTokenPolicyStrategy: {1}", jsonString, exception.ToString()));
            }

            try
            {
                newPolicyStrategy = new PolicyStrategy(JsonConvert.DeserializeObject<FixedRateTokenPolicyStrategy>(jsonString, PolicyStrategy.SerializerSettings));
                // deserialization is considered successful at this point if no exception has been thrown.
                return newPolicyStrategy;
            }
            catch (Exception exception)
            {
                // deserialization failed, try the next one
                System.Diagnostics.Debug.WriteLine(string.Format("Failed to deserialize `{0}` into FixedRateTokenPolicyStrategy: {1}", jsonString, exception.ToString()));
            }

            try
            {
                newPolicyStrategy = new PolicyStrategy(JsonConvert.DeserializeObject<PayForUserPolicyStrategy>(jsonString, PolicyStrategy.SerializerSettings));
                // deserialization is considered successful at this point if no exception has been thrown.
                return newPolicyStrategy;
            }
            catch (Exception exception)
            {
                // deserialization failed, try the next one
                System.Diagnostics.Debug.WriteLine(string.Format("Failed to deserialize `{0}` into PayForUserPolicyStrategy: {1}", jsonString, exception.ToString()));
            }

            // no match found, throw an exception
            throw new InvalidDataException("The JSON string `" + jsonString + "` cannot be deserialized into any schema defined.");
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as PolicyStrategy);
        }

        /// <summary>
        /// Returns true if PolicyStrategy instances are equal
        /// </summary>
        /// <param name="input">Instance of PolicyStrategy to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(PolicyStrategy input)
        {
            if (input == null)
                return false;

            return this.ActualInstance.Equals(input.ActualInstance);
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hashCode = 41;
                if (this.ActualInstance != null)
                    hashCode = hashCode * 59 + this.ActualInstance.GetHashCode();
                return hashCode;
            }
        }

    }

    /// <summary>
    /// Custom JSON converter for PolicyStrategy
    /// </summary>
    public class PolicyStrategyJsonConverter : JsonConverter
    {
        /// <summary>
        /// To write the JSON string
        /// </summary>
        /// <param name="writer">JSON writer</param>
        /// <param name="value">Object to be converted into a JSON string</param>
        /// <param name="serializer">JSON Serializer</param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteRawValue((string)(typeof(PolicyStrategy).GetMethod("ToJson").Invoke(value, null)));
        }

        /// <summary>
        /// To convert a JSON string into an object
        /// </summary>
        /// <param name="reader">JSON reader</param>
        /// <param name="objectType">Object type</param>
        /// <param name="existingValue">Existing value</param>
        /// <param name="serializer">JSON Serializer</param>
        /// <returns>The object converted from the JSON string</returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if(reader.TokenType != JsonToken.Null)
            {
                return PolicyStrategy.FromJson(JObject.Load(reader).ToString(Formatting.None));
            }
            return null;
        }

        /// <summary>
        /// Check if the object can be converted
        /// </summary>
        /// <param name="objectType">Object type</param>
        /// <returns>True if the object can be converted</returns>
        public override bool CanConvert(Type objectType)
        {
            return false;
        }
    }

}
