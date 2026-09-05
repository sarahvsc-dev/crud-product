using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductSystem.Data;
using ProductSystem.Models;

namespace ProductSystem.Controllers
{
    public class ProductsController: Controller
    {
        //CRIA UM "ESPAÇO" NO ARMAZENAMENTO
        private readonly AppDbContext _context;

        //INJEÇÃO DE DEPENDÊNCIA (PODE ATRIBUIR VALORES ATRAVÉS DO CONSTRUTOR)
        public ProductsController(AppDbContext context)
        {
            _context = context;
        }
        //OPERAÇÃO ASSÍNCRONA-"PEGUE OS PRODUCTS E TRANSFORME ELES EM UMA LISTA"
        public async Task<IActionResult> Index()
        {
            var products = await _context.Products.ToListAsync();
            //"MANDE OS PRODUCTS PARA PASTA PRODUCT DENTRO DE INDEX.CSHTML"
            return View(products);
        }
        //ABRE PASTA PRODUCT E MOSTRA O CREATE.CSHTML
        public IActionResult Create()
        {
            return View();
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            //PROCURE A TABELA PRODUCTS QUE O ID SEJA IGUAL AO ID QUE EU PASSEI
            var product = await _context.Products
                .FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }
            //RETORNA PARA VIEW Detail.cshtml
            return View(product);

        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
            //BUSCA O PRODUTO E ABRE O FORMULÁRIO
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }
            //RECEBE O PRODUTO ALTERADO
            _context.Products.Update(product);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            //PROCURA O PRODUDO POR ID
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }
        //ABRE O FORMULÁRIO E RECEBE OS DADOS DO FORMULÁRIO
        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            product.RegistrationDate = DateTime.Now;

            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            //SALVA NO BANCO DE DADOS
            return RedirectToAction(nameof(Index));
            //VOLTA PARA A PAGINA INDEX
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }
            //DELETA O PRODUTO POR ID
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
