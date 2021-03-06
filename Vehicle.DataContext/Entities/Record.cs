// <auto-generated>
// ReSharper disable CheckNamespace
// ReSharper disable ConvertPropertyToExpressionBody
// ReSharper disable DoNotCallOverridableMethodsInConstructor
// ReSharper disable EmptyNamespace
// ReSharper disable InconsistentNaming
// ReSharper disable NotAccessedVariable
// ReSharper disable PartialMethodWithSinglePart
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable RedundantCast
// ReSharper disable RedundantNameQualifier
// ReSharper disable RedundantOverridenMember
// ReSharper disable UseNameofExpression
// ReSharper disable UsePatternMatching
#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Vehicle.DataContext
{
    // Record
    public class Record
    {
        public int Id { get; set; } // Id (Primary key)
        public int VehicleId { get; set; } // VehicleId
        public decimal Latitude { get; set; } // Latitude
        public decimal Longitude { get; set; } // Longitude
        public int Speed { get; set; } // Speed
        public DateTime Timestamp { get; set; } // Timestamp

        // Foreign keys

        /// <summary>
        /// Parent Vehicle pointed by [Record].([VehicleId]) (FK_Record_Vehicle)
        /// </summary>
        public virtual Vehicle Vehicle { get; set; } // FK_Record_Vehicle
    }

}
// </auto-generated>

