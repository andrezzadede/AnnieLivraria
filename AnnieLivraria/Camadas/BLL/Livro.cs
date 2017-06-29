using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnieLivraria.Camadas.BLL
{
    public class Livro
    {
        public List<Model.Livro> Select()
        {
            DAL.Livro dalLivro = new DAL.Livro();
            return dalLivro.Select();
        }

        public List<Model.Livro> SelectByid (int id)
        {
            DAL.Livro dalLivro = new DAL.Livro();
            return dalLivro.SelectByid(id);
        }

        public List<Model.Livro> SelectByNome(string Nome)
        {
            DAL.Livro dalLivro = new DAL.Livro();
            return dalLivro.SelectByNome(Nome);
        }

        public void Insert(Model.Livro Livro)
        {
            DAL.Livro dalLivro = new DAL.Livro();
            dalLivro.Insert(Livro);
        }

        public void Update(Model.Livro Livro)
        {
            DAL.Livro dalLivro = new DAL.Livro();
            dalLivro.Update(Livro);
        }

        public void Delete(Model.Livro Livro)
        {
            DAL.Livro dalLivro = new DAL.Livro();
            dalLivro.Delete(Livro);
        }

    }
}
