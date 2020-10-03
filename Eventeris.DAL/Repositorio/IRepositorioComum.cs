using System;
using System.Collections.Generic;
using System.Text;

namespace Eventeris.DAL.Repositorio
{
	public interface IRepositorioComum<T>
	{
		T Adicionar(T entity);

		T Atualizar(T entity);

		List<T> Listar();

		T Encontrar(int id);

	}
}
