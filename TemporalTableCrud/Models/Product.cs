using System;
using System.ComponentModel.DataAnnotations;

namespace TemporalTableCrud.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do produto é obrigatório.")]
        public string Name { get; set; }
    }
}