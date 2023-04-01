using Microsoft.AspNetCore.Mvc;
using JRS.Repository;
using JRS.Models;

namespace SampleCRUD.Controllers
{
    public class UserController : Controller
    {
        IUserDBRepository _userRepository;
        IRoleDBRepository _roleRepository;
        public UserController(IUserDBRepository userRepository, IRoleDBRepository roleRepository)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }

        public async Task<IActionResult> GetAllUsers()
        {
            return View(await _userRepository.GetAllUsers());
        }

        // [HttpGet]
        public async Task<IActionResult> Create()
        {
            CreateUserViewModel createUserViewModel = new CreateUserViewModel
            {
                Roles = await _roleRepository.GetAllRoles()
            };

            return View(createUserViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateUserViewModel createUserViewModel)
        {
            createUserViewModel.Roles = await _roleRepository.GetAllRoles();

            if (ModelState.IsValid)
            {
                User newUser = new User
                {
                    FirstName = createUserViewModel.NewUser.FirstName,
                    LastName = createUserViewModel.NewUser.LastName,
                    BirthDate = createUserViewModel.NewUser.Birthdate,
                    ContactNo = createUserViewModel.NewUser.ContactNo,
                    Email = createUserViewModel.NewUser.Email,
                    Address = createUserViewModel.NewUser.Address,
                    Username = createUserViewModel.NewUser.Username,
                    RoleId = createUserViewModel.NewUser.RoleId
                };

                await _userRepository.AddUser(newUser);

                return RedirectToAction(nameof(GetAllUsers));
            }

            return View(createUserViewModel);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _userRepository.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }
        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_userRepository.GetAllUsers() == null)
            {
                return Problem("Entity set 'SampleDBContext.Users'  is null.");
            }

            var user = await _userRepository.GetUserById(id);

            if (_userRepository is null)
            {
                return NotFound();
            }

            await _userRepository.DeleteUser(user.UserId);
            return RedirectToAction(nameof(GetAllUsers));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _userRepository.GetUserById(id);

            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

    }
}
