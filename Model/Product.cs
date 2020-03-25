using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
namespace Model
{
    public class Product
    {

        [Key]
        public string ID { get; set; }
        [Required]
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Categoria { get; set; }
        [Required]
        public int Cantidad { get; set; }
        [Column(TypeName="decimal(9,2)")]
        [Required]
        public decimal Precio { get; set; }
        public string IdReferencia { get; set; }

    }
}
