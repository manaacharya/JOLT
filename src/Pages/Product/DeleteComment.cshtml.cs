using System.Linq;

using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;

namespace ContosoCrafts.WebSite.Pages.Product
{
    /// <summary>
    /// Manage the Delete of the data for a single record
    /// </summary>
    public class DeleteCommentModel : PageModel
    {
        // Data middletier
        public JsonFileProductService ProductService { get; }

        /// <summary>
        /// Defualt Construtor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="productService"></param>
        public DeleteCommentModel(JsonFileProductService productService)
        {
            ProductService = productService;
        }

        // The data to show, bind to it for the post
        [BindProperty]
        public ProductModel Product { get; set; }

        // The ID of the product passed in
        public string ProductId { get; set; }

        // The ID for this commment
        public string CommentId { get; set; }

        // The Comment Text
        public string CommentText { get; set; }

        /// <summary>
        /// Get the comment passed in for the product
        /// </summary>
        /// <param name="id"></param>
        public void OnGet(string CommentId, string ProductId)
        {
            Product = ProductService.GetAllData().FirstOrDefault(m => m.Id.Equals(ProductId));
            var data = Product.CommentList.First(m => m.Id.Equals(CommentId));

            // Set the values for Product ID, Comment ID and Comment to show on the page
            ProductId = Product.Id;
            CommentId = CommentId;
            CommentText = data.Comment;
        }

        /// <summary>
        /// Remove the Comment from the Product
        /// </summary>
        /// <returns></returns>
        public IActionResult OnPost(string CommentId, string ProductId)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Lookup the Item
            Product = ProductService.GetAllData().FirstOrDefault(m => m.Id.Equals(ProductId));

            // Find the comment in this CommentList, and remove it
            var data = Product.CommentList.First(m => m.Id.Equals(CommentId));
            Product.CommentList.Remove(data);

            // Save the updated product
            ProductService.UpdateData(Product);

            // Redirect to the Read page, pass in the Product ID for the read to happen
            return RedirectToPage("./Read", new { Id = ProductId });
        }
    }
}