using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
//using ramzi_project_api.Models;
using ramzi_project_api.Models; // تأكد من وجود هذا الـ using لاستدعاء DbContext

namespace ramzi_project_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductsController(AppDbContext context)
        {
            _context = context;
        }

        // 🟢 إضافة منتج جديد إلى قاعدة البيانات
        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Add(product);
                await _context.SaveChangesAsync();
                return Ok("Product added to database successfully");
            }

            return BadRequest(ModelState);
        }

        // استرجاع كل المنتجات من قاعدة البيانات
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetAllProducts()
        {
            var products = await _context.Products.ToListAsync();
            return Ok(products);
        }

        //  استرجاع منتج واحد حسب المعرف
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductById(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
                return NotFound("Product not found");

            return Ok(product);
        }


        // تعديل منتج
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] Product updatedProduct)
        {
            if (id != updatedProduct.Id)
                return BadRequest("مفتاح المنتج غير موجود");

            var product = await _context.Products.FindAsync(id);
            if (product == null)
                return NotFound("Product not found");

            product.Name = updatedProduct.Name;
            product.Price = updatedProduct.Price;
            // أضف أي خصائص أخرى حسب النموذج

            await _context.SaveChangesAsync();
            return Ok("Product updated successfully");
        }

        //  حذف منتج
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
                return NotFound("Product not found");

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return Ok("Product deleted successfully");
        }
    }
}

       



    
