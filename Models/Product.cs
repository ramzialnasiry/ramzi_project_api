using System.ComponentModel.DataAnnotations;

namespace ramzi_project_api.Models
{
    public class Product
    {


            [Key]
            public int Id { get; set; }

        [Required(ErrorMessage = "اسم المنتج مطلوب")]
        [StringLength(100, ErrorMessage = "اسم المنتج يجب ألا يتجاوز 100 حرف")]
        public string Name { get; set; }


        public decimal Price { get; set; }
       


    }
}
