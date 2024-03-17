using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AgencyDomain.Model;
using AgencyInfrastructure;

namespace AgencyInfrastructure.Controllers
{
    public class PropertiesController : Controller
    {
        private readonly DbagencyContext _context;

        public PropertiesController(DbagencyContext context)
        {
            _context = context;
        }

        // GET: Properties
        public async Task<IActionResult> Index(int? id, string? name)
        {
            if (id == null) return RedirectToAction("Index","PropertyTypes");
            ViewBag.PropertyTypeId = id;
            ViewBag.PropertyTypeName = name;
            var dbagencyContext = _context.Properties.Include(a => a.Address).Include(c => c.Agent).Where(b => b.PropertyTypeId == id).Include(b => b.PropertyType);
            
            return View(await dbagencyContext.ToListAsync());
        }

        //GET: Properties/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @property = await _context.Properties
                .Include(a => a.Address)
                .Include(c => c.Agent)
                .Include(b => b.PropertyType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (@property == null)
            {
                return NotFound();
            }

            return View(@property);
        }

        // GET: Properties/Create
        public IActionResult Create(int propertyTypeId)
        {
            ViewData["AddressId"] = new SelectList(_context.Addresses, "Id", "Id");
            ViewData["AgentId"] = new SelectList(_context.Agents, "Id", "Id");
            //ViewData["PropertyTypeId"] = new SelectList(_context.PropertyTypes, "Id", "TypeName");
            ViewBag.PropertyTypeId = propertyTypeId;
            ViewBag.PropertyTypeName = _context.PropertyTypes.Where(c => c.Id == propertyTypeId).FirstOrDefault().TypeName;
            return View();
        }

        // POST: Properties/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int propertyTypeId, [Bind("Id,PropertyTypeId,AgentId,AddressId,Price,Size,Bedrooms,Bathrooms,Status")] Property property)
        {
            property.PropertyTypeId = propertyTypeId;
            if (ModelState.IsValid)
            {
                _context.Add(property);
                await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
                return RedirectToAction("Index", "Properties", new { id = propertyTypeId, name = _context.PropertyTypes.Where(c => c.Id == propertyTypeId).FirstOrDefault().TypeName });
            }
            ViewData["AddressId"] = new SelectList(_context.Addresses, "Id", "Id", property.AddressId);
            ViewData["AgentId"] = new SelectList(_context.Agents, "Id", "Id", property.AgentId);
            //ViewData["PropertyTypeId"] = new SelectList(_context.PropertyTypes, "Id", "TypeName", property.PropertyTypeId);
            //return View(property);
            return RedirectToAction("Index", "Properties", new { id = propertyTypeId, name = _context.PropertyTypes.Where(c => c.Id == propertyTypeId).FirstOrDefault().TypeName });
        }

        // GET: Properties/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @property = await _context.Properties.FindAsync(id);
            if (@property == null)
            {
                return NotFound();
            }
            ViewData["AddressId"] = new SelectList(_context.Addresses, "Id", "Id", @property.AddressId);
            ViewData["AgentId"] = new SelectList(_context.Agents, "Id", "Id", @property.AgentId);
            ViewData["PropertyTypeId"] = new SelectList(_context.PropertyTypes, "Id", "TypeName", @property.PropertyTypeId);
            return View(@property);
        }

        // POST: Properties/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PropertyTypeId,AgentId,AddressId,Price,Size,Bedrooms,Bathrooms,Status")] Property @property)
        {
            if (id != @property.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(@property);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PropertyExists(@property.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["AddressId"] = new SelectList(_context.Addresses, "Id", "Id", @property.AddressId);
            ViewData["AgentId"] = new SelectList(_context.Agents, "Id", "Id", @property.AgentId);
            ViewData["PropertyTypeId"] = new SelectList(_context.PropertyTypes, "Id", "TypeName", @property.PropertyTypeId);
            return View(@property);
        }

        // GET: Properties/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @property = await _context.Properties
                .Include(a => a.Address)
                .Include(c => c.Agent)
                .Include(b => b.PropertyType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (@property == null)
            {
                return NotFound();
            }

            return View(@property);
        }

        // POST: Properties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var @property = await _context.Properties.FindAsync(id);
            if (@property != null)
            {
                _context.Properties.Remove(@property);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PropertyExists(int id)
        {
            return _context.Properties.Any(e => e.Id == id);
        }
    }
}
