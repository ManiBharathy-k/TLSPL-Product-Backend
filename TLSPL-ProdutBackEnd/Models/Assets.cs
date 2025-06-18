using System.ComponentModel.DataAnnotations;

namespace TLSPL_ProdutBackEnd.Models
{
    public class Assets
    {
        [Key]
        public int AssetId { get; set; } // asset_id

        [Required]
        public string Barcode { get; set; } // barcode

        [Required]
        public string AssetTag { get; set; } // asset_tag

        [Required]
        public string AssetName { get; set; } // asset_name

        [Required]
        public string Description { get; set; } // description

        [Required]
        public string Category { get; set; } // category

        [Required]
        public string Location { get; set; } // location

        [Required]
        public string AssignedTo { get; set; } // assigned_to

        [Required]
        public AssetStatus Status { get; set; } // status (ENUM)

        [Required]
        public string AssetType { get; set; } // AssetType

        [Required]
        public string VendorId { get; set; } // Vendor_ID

        public DateTime PurchaseDate { get; set; } // purchase_date
        public DateTime? WarrantyUntil { get; set; } // warranty_until
        public decimal Cost { get; set; } // cost
        public DateTime CreatedAt { get; set; } // created_at
        public DateTime UpdatedAt { get; set; } // updated_at
    }

    public enum AssetStatus
    {
        Active,
        Inactive,
        Maintenance,
        Retired,
        Lost
    }
}
