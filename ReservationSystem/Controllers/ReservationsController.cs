﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReservationSystem.Middleware;
using ReservationSystem.Models;
using ReservationSystem.Services;

namespace ReservationSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly ReservationContext _context;
        private readonly IReservationService _service;
        private readonly IUserAuthenticationService _authenticationService;


        public ReservationsController(IReservationService service, IUserAuthenticationService authenticationService, ReservationContext context)
        {
            _service = service;
            _authenticationService = authenticationService;
            _context = context;
        }

        
        [HttpGet] //Get reservations
        public async Task<ActionResult<IEnumerable<ReservationDTO>>> GetReservations()
        {
           
            return Ok(await _service.GetAllReservations());
        }

  

        //Get reservations via id
        // GET: api/Reservations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<ReservationDTO>>> GetReservation(long id)
        {
           var reservation = await _service.GetReservation(id);
         if (reservation == null)
         {
             return NotFound();
         }
        
            return Ok(reservation);
        }

        //Get reservations via username
        // GET: api/Reservation/user/username
        [HttpGet("user/{username}")]
        public async Task<ActionResult<IEnumerable<ReservationDTO>>> GetReservations(String username)
        {
            return Ok(await _service.GetAllReservationsForUser(username));

        }

        //Edit reservations
        // PUT: api/Reservations/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]

        //Kutsuu servicen update reservation
        public async Task<IActionResult> PutReservation(long id, ReservationDTO reservation)
        {
            if (id != reservation.Id)
            {
                return BadRequest();
            }

            _context.Entry(reservation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return null;
            }
            return NoContent();
        }

        //Make reservation
        // POST: api/Reservations
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<ReservationDTO>> PostReservation(ReservationDTO reservation)
        {
            // oikeus lisätä varaus
            bool isAllowed = await _authenticationService.IsAllowed(this.User.FindFirst(ClaimTypes.Name).Value, reservation);
            if (!isAllowed)
            { return Unauthorized(); }
            reservation = await _service.CreateReservationAsync(reservation);
            if (reservation == null)
            {
                return StatusCode(500);
            }

            return CreatedAtAction("GetReservation", new { id = reservation.Id }, reservation);
            
        }

        //Delete reservation
        // DELETE: api/Reservations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Reservation>> DeleteReservation(long id)
        {
            var reservation = await _context.Reservations.FindAsync(id);
            if (reservation == null)
             {
                 return NotFound();
             }

              _context.Reservations.Remove(reservation);
             await _context.SaveChangesAsync();

             return reservation;
            //return null;
        }
    }
}
