using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Site.Core.Exceptions;
using Site.Domain.Entities;
using Site.Infra.Interfaces;
using Site.Services.DTO;
using Site.Services.Interface;

namespace Site.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public UserService(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<UserDTO> Create(UserDTO userDTO)
        {
            var userExists = await _userRepository.GetByEmail(userDTO.Email);

            if (userExists != null)
                throw new DomainException("Já existe um usuário cadastrado com email informado");

            var user = _mapper.Map<User>(userDTO);
            user.Validate();

            var userCreated = await _userRepository.Create(user);

            return _mapper.Map<UserDTO>(userCreated);
        }
        public async Task<UserDTO> Update(UserDTO userDTO)
        {
            var userExists = await _userRepository.Get(userDTO.Id);

            if (userExists != null)
                throw new DomainException("Já existe nenhum usuário com o id informado");

            var user = _mapper.Map<User>(userDTO);
            user.Validate();

            var userUpdated = await _userRepository.Create(user);

            return _mapper.Map<UserDTO>(userUpdated);
        }
        public async Task Remove(long id)
        {
            await _userRepository.Remove(id);
        }
        public async Task<List<UserDTO>> Get(long id)
        {
            var user = await _userRepository.Get(id);
            return _mapper.Map<List<UserDTO>>(user);
        }
        public async Task<List<UserDTO>> Get()
        {
            var allUsers = await _userRepository.Get();
            return _mapper.Map<List<UserDTO>>(allUsers);
        }
        public async Task<List<UserDTO>> SearchByName(string name)
        {
            var user = await _userRepository.SearchByName(name);
            return _mapper.Map<List<UserDTO>>(user);
        }
        public async Task<List<UserDTO>> SearchByEmail(string email)
        {
            var user = await _userRepository.SearchByEmail(email);
            return _mapper.Map<List<UserDTO>>(user);
        }
        public async Task<UserDTO> GetByEmail(string email)
        {
            var user = await _userRepository.GetByEmail(email);
            return _mapper.Map<UserDTO>(user);
        }
    }
}