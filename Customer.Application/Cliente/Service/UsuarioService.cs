using AutoMapper;
using Customer.Application.Cliente.Dto;
using Customer.CrossCutting.JwtService.Contracts;
using Customer.CrossCutting.JwtService.Dto;
using Customer.Domain.Account.Repository;
using Microsoft.AspNetCore.Mvc;
using static Customer.Application.Cliente.Dto.UsuarioDto;

namespace Customer.Application.Cliente.Service
{
    public class UsuarioService: IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;
        private readonly IJwtService _jwtService;

        public UsuarioService(IUsuarioRepository usuarioRepository, IMapper mapper, IJwtService jwtService)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
            _jwtService = jwtService;
        }

        public async Task<UsuarioOutputDto> Criar(UsuarioInputDto dto)
        {
            if (await _usuarioRepository.AnyAsync(x => x.Email.Valor == dto.Email.Valor))
                throw new Exception("Já existe um usuário cadastrado com o email informado");

            var usuario = this._mapper.Map<Customer.Domain.Account.Usuario>(dto);

            usuario.Validate();
            usuario.SetPassword();

            usuario.Id = Guid.NewGuid();

            await _usuarioRepository.Save(usuario);

            return this._mapper.Map<UsuarioOutputDto>(usuario);

        }

        public async Task<UsuarioOutputDto> Deletar([FromBody] UsuarioInputDto dto)
        {
            var usuario = this._mapper.Map<Customer.Domain.Account.Usuario>(dto);

            await this._usuarioRepository.Delete(usuario);

            return this._mapper.Map<UsuarioOutputDto>(usuario);

        }

        public async Task<UsuarioOutputDto> Atualizar(UsuarioInputDto dto)
        {
            if (!dto.Id.HasValue) throw new Exception("Usuário não encontrado");

            if (await _usuarioRepository.AnyAsync(x => x.Email.Valor == dto.Email.Valor && x.Id != dto.Id))
                throw new Exception("Já existe um usuário cadastrado com o email informado");

            var usuario = await _usuarioRepository.GetbyExpressionAsync(x => x.Id == dto.Id.Value);
            if (usuario is null) throw new Exception("Usuário não encontrado");

            usuario.Update(dto.Nome, dto.Email, dto.Password, dto.TipoUsuario);

            await this._usuarioRepository.Update(usuario);

            return this._mapper.Map<UsuarioOutputDto>(usuario);

        }

        public async Task<List<UsuarioOutputDto>> ObterTodos()
        {

            var usuario = await this._usuarioRepository.GetAll();

            return this._mapper.Map<List<UsuarioOutputDto>>(usuario);
        }

        public async Task<UsuarioOutputDto> ObterPorId(Guid id)
        {
            var usuario = await this._usuarioRepository.Get(id);

            return this._mapper.Map<UsuarioOutputDto>(usuario);

        }

        public async Task<string> ObterTokenJwtAsync(LoginDto dto)
        {
            var usuario = await _usuarioRepository.GetbyExpressionAsync(x => x.Email.Valor == dto.Email && x.Password.Valor == dto.Password);

            if (usuario is null) throw new Exception("Usuário não encontrado");

            return await _jwtService.GenerateToken(new JwtDto(usuario.Id, usuario.Email?.Valor));
        }
    }
}


