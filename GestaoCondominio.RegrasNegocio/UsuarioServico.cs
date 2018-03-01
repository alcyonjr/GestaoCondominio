using GestaoCondominio.Dominio;
using GestaoCondominio.Repositorio.DAO;
using Jose;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Security.Cryptography;
using System.Text;

namespace GestaoCondominio.Servico
{
    public class UsuarioService
    {
        private readonly UsuarioRepositorio repositorio = new UsuarioRepositorio();
        private readonly String SALT = "salt_gestao_condominio";

        public void Inserir(Usuario novoUsuario)
        {
            ValidarUsuarioInformado(novoUsuario);
            IsUsuarioExiste(novoUsuario);            
            novoUsuario.senha = GerarHash(novoUsuario);
            repositorio.Inserir(novoUsuario);
        }

        public IList<Usuario> Consultar()
        {
            return repositorio.Consultar();
        }

        public void Excluir(Usuario usuario)
        {
            IsUsuarioExiste(usuario);
            repositorio.Excluir(usuario);
        }

        public String Autenticar(Usuario usuario)
        {
            ValidarUsuarioInformado(usuario);

            Usuario usuarioReposiorio = repositorio.BuscarPorLogin(usuario);

            if (usuarioReposiorio == null)
                throw new ApplicationException("Usuário ou senha incorretos.");
            
            if (!usuarioReposiorio.senha.Equals(GerarHash(usuario)))
                throw new ApplicationException("Usuário ou senha incorretos.");

            
            return GerarJwtToken(usuarioReposiorio);
        }        

        private String GerarJwtToken(Usuario usuario)
        {
            Int32 timestampExpiracao = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            timestampExpiracao += 43200; //12h
            var payload = new Dictionary<string, object>
            {
                { "sub", usuario.login},
                { "exp", timestampExpiracao }
            };

            var secretKey = Encoding.UTF8.GetBytes(ConfigurationManager.AppSettings["Chave"]);

            return JWT.Encode(payload, secretKey, JwsAlgorithm.HS512);
        }

        private void IsUsuarioExiste(Usuario novoUsuario)
        {
            Usuario usuarioReposiorio = repositorio.BuscarPorLogin(novoUsuario);

            if (usuarioReposiorio != null)
                throw new ApplicationException("Usuário já existe na sistema.");
        }

        private void ValidarUsuarioInformado(Usuario usuario)
        {
            if (String.IsNullOrWhiteSpace(usuario.login))
                throw new ApplicationException("Informar login.");

            if (String.IsNullOrWhiteSpace(usuario.senha))
                throw new ApplicationException("Informar senha.");
        }

        private String GerarHash(Usuario usuario)
        {
            return Sha256(usuario.senha + SALT);
        }

        private string Sha256(string randomString)
        {
            var crypt = new SHA256Managed();
            string hash = String.Empty;
            byte[] crypto = crypt.ComputeHash(Encoding.ASCII.GetBytes(randomString));
            foreach (byte theByte in crypto)
            {
                hash += theByte.ToString("x2");
            }
            return hash;
        }
    }
}
