using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using DinnerPartyRoa.Models;

namespace DinnerPartyRoa.Controllers
{
    public class MenuItemsapiController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/MenuItemsapi
        public IQueryable<MenuItem> GetMenuItems()
        {
            return db.MenuItems.Where(w => w.IsDeleted != 1);
        }

        // GET: api/MenuItemsapi/5
        [ResponseType(typeof(MenuItem))]
        public async Task<IHttpActionResult> GetMenuItem(int id)
        {
            MenuItem menuItem = await db.MenuItems.FindAsync(id);
            if (menuItem == null)
            {
                return NotFound();
            }

            return Ok(menuItem);
        }

        // PUT: api/MenuItemsapi/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutMenuItem(int id, MenuItem menuItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != menuItem.Id)
            {
                return BadRequest();
            }

            db.Entry(menuItem).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MenuItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/MenuItemsapi
        [ResponseType(typeof(MenuItem))]
        public async Task<IHttpActionResult> PostMenuItem(MenuItem menuItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MenuItems.Add(menuItem);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = menuItem.Id }, menuItem);
        }

        // DELETE: api/MenuItemsapi/5
        [ResponseType(typeof(MenuItem))]
        public async Task<IHttpActionResult> DeleteMenuItem(int id)
        {
            MenuItem menuItem = await db.MenuItems.FindAsync(id);
            if (menuItem == null)
            {
                return NotFound();
            }

            db.MenuItems.Remove(menuItem);
            await db.SaveChangesAsync();

            return Ok(menuItem);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MenuItemExists(int id)
        {
            return db.MenuItems.Count(e => e.Id == id) > 0;
        }
    }
}