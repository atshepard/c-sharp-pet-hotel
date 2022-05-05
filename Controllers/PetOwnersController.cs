using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using pet_hotel.Models;
using Microsoft.EntityFrameworkCore;

namespace pet_hotel.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetOwnersController : ControllerBase
    {
        private readonly ApplicationContext _context;
        public PetOwnersController(ApplicationContext context) {
            _context = context;
        }

        // This is just a stub for GET / to prevent any weird frontend errors that 
        // occur when the route is missing in this controller
        [HttpGet]
        public IEnumerable<PetOwner> GetAllOwners() {
            return _context.PetOwnerTable;
        }

        [HttpPost]
        public PetOwner Post(PetOwner owner) {
            _context.Add(owner);
            _context.SaveChanges();

            return owner;
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var ownerToDelete = _context.PetOwnerTable.SingleOrDefault(petOwner => petOwner.id == id);

            if (ownerToDelete == null) {
                return NotFound();
            }

            _context.Remove(ownerToDelete);
            _context.SaveChanges();

            return NoContent();
        }

    }
}
