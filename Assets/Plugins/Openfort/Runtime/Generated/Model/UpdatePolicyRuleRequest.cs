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
    /// UpdatePolicyRuleRequest
    /// </summary>
    [DataContract(Name = "UpdatePolicyRuleRequest")]
    public partial class UpdatePolicyRuleRequest : IEquatable<UpdatePolicyRuleRequest>
    {

        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [DataMember(Name = "type", IsRequired = true, EmitDefaultValue = true)]
        public PolicyRuleType Type { get; set; }

        /// <summary>
        /// Gets or Sets TimeIntervalType
        /// </summary>
        [DataMember(Name = "timeIntervalType", EmitDefaultValue = false)]
        public TimeIntervalType? TimeIntervalType { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdatePolicyRuleRequest" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected UpdatePolicyRuleRequest() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdatePolicyRuleRequest" /> class.
        /// </summary>
        /// <param name="type">type (required).</param>
        /// <param name="functionName">Name of the function in the contract to allow..</param>
        /// <param name="contract">Contract ID to allow..</param>
        /// <param name="gasLimit">Gas limit in WEI..</param>
        /// <param name="countLimit">Number of times the function will be sponsored..</param>
        /// <param name="timeIntervalType">timeIntervalType.</param>
        /// <param name="timeIntervalValue">Time interval value..</param>
        public UpdatePolicyRuleRequest(PolicyRuleType type = default(PolicyRuleType), string functionName = default(string), string contract = default(string), string gasLimit = default(string), int countLimit = default(int), TimeIntervalType? timeIntervalType = default(TimeIntervalType?), int timeIntervalValue = default(int))
        {
            this.Type = type;
            this.FunctionName = functionName;
            this.Contract = contract;
            this.GasLimit = gasLimit;
            this.CountLimit = countLimit;
            this.TimeIntervalType = timeIntervalType;
            this.TimeIntervalValue = timeIntervalValue;
        }

        /// <summary>
        /// Name of the function in the contract to allow.
        /// </summary>
        /// <value>Name of the function in the contract to allow.</value>
        [DataMember(Name = "functionName", EmitDefaultValue = true)]
        public string FunctionName { get; set; }

        /// <summary>
        /// Contract ID to allow.
        /// </summary>
        /// <value>Contract ID to allow.</value>
        [DataMember(Name = "contract", EmitDefaultValue = true)]
        public string Contract { get; set; }

        /// <summary>
        /// Gas limit in WEI.
        /// </summary>
        /// <value>Gas limit in WEI.</value>
        [DataMember(Name = "gasLimit", EmitDefaultValue = false)]
        public string GasLimit { get; set; }

        /// <summary>
        /// Number of times the function will be sponsored.
        /// </summary>
        /// <value>Number of times the function will be sponsored.</value>
        [DataMember(Name = "countLimit", EmitDefaultValue = false)]
        public int CountLimit { get; set; }

        /// <summary>
        /// Time interval value.
        /// </summary>
        /// <value>Time interval value.</value>
        [DataMember(Name = "timeIntervalValue", EmitDefaultValue = false)]
        public int TimeIntervalValue { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class UpdatePolicyRuleRequest {\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  FunctionName: ").Append(FunctionName).Append("\n");
            sb.Append("  Contract: ").Append(Contract).Append("\n");
            sb.Append("  GasLimit: ").Append(GasLimit).Append("\n");
            sb.Append("  CountLimit: ").Append(CountLimit).Append("\n");
            sb.Append("  TimeIntervalType: ").Append(TimeIntervalType).Append("\n");
            sb.Append("  TimeIntervalValue: ").Append(TimeIntervalValue).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as UpdatePolicyRuleRequest);
        }

        /// <summary>
        /// Returns true if UpdatePolicyRuleRequest instances are equal
        /// </summary>
        /// <param name="input">Instance of UpdatePolicyRuleRequest to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(UpdatePolicyRuleRequest input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.Type == input.Type ||
                    this.Type.Equals(input.Type)
                ) && 
                (
                    this.FunctionName == input.FunctionName ||
                    (this.FunctionName != null &&
                    this.FunctionName.Equals(input.FunctionName))
                ) && 
                (
                    this.Contract == input.Contract ||
                    (this.Contract != null &&
                    this.Contract.Equals(input.Contract))
                ) && 
                (
                    this.GasLimit == input.GasLimit ||
                    (this.GasLimit != null &&
                    this.GasLimit.Equals(input.GasLimit))
                ) && 
                (
                    this.CountLimit == input.CountLimit ||
                    this.CountLimit.Equals(input.CountLimit)
                ) && 
                (
                    this.TimeIntervalType == input.TimeIntervalType ||
                    this.TimeIntervalType.Equals(input.TimeIntervalType)
                ) && 
                (
                    this.TimeIntervalValue == input.TimeIntervalValue ||
                    this.TimeIntervalValue.Equals(input.TimeIntervalValue)
                );
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
                hashCode = (hashCode * 59) + this.Type.GetHashCode();
                if (this.FunctionName != null)
                {
                    hashCode = (hashCode * 59) + this.FunctionName.GetHashCode();
                }
                if (this.Contract != null)
                {
                    hashCode = (hashCode * 59) + this.Contract.GetHashCode();
                }
                if (this.GasLimit != null)
                {
                    hashCode = (hashCode * 59) + this.GasLimit.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.CountLimit.GetHashCode();
                hashCode = (hashCode * 59) + this.TimeIntervalType.GetHashCode();
                hashCode = (hashCode * 59) + this.TimeIntervalValue.GetHashCode();
                return hashCode;
            }
        }

    }

}
