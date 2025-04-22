using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MatriculaITM.Models;

namespace MatriculaITM.Clases
{
	public class ManejoMatricula
	{
        private DBExamenEntities db = new DBExamenEntities();

        public string Ingresar(Matricula matricula)
        {
            var estudianteExiste = db.Estudiantes.Any(e => e.idEstudiante == matricula.idEstudiante);
            if (!estudianteExiste)
            {
                return "Error: El estudiante especificado no existe.";
            }
            if (matricula.NumeroCreditos <= 0 || matricula.ValorCredito <= 0)
            {
                return "Error: Número de créditos y valor del crédito deben ser mayores a cero.";
            }
            int totalCalculado = matricula.NumeroCreditos * matricula.ValorCredito;
            if (matricula.TotalMatricula != totalCalculado)
            {
                return $"Error: El total de matrícula debe ser igual a créditos * valor crédito. Total esperado: {totalCalculado}";
            }
            if (matricula.FechaMatricula > DateTime.Now.Date)
            {
                return "Error: La fecha de matrícula no puede ser futura.";
            }
            if (string.IsNullOrWhiteSpace(matricula.SemestreMatricula) ||
                !System.Text.RegularExpressions.Regex.IsMatch(matricula.SemestreMatricula, @"^\d{4}-(1|2)$"))
            {
                return "Error: El formato del semestre es incorrecto (Ejemplo: 2024-1).";
            }
            if (string.IsNullOrWhiteSpace(matricula.MateriasMatriculadas))
            {
                return "Error: Debes ingresar las asignaturas matriculadas.";
            }
            var yaExiste = db.Matriculas.Any(m =>
                m.idEstudiante == matricula.idEstudiante &&
                m.SemestreMatricula == matricula.SemestreMatricula);
            if (yaExiste)
            {
                return "Error: El estudiante ya tiene matrícula registrada para ese semestre.";
            }

            db.Matriculas.Add(matricula);
            db.SaveChanges();

            return "Matrícula registrada correctamente.";
        }
        public List<Matricula> ConsultarPorDocumentoYSemestre(string documento, string semestre)
        {
            var estudiante = db.Estudiantes.FirstOrDefault(e => e.Documento == documento);

            if (estudiante == null)
            {
                return null; // No existe el estudiante
            }

            return db.Matriculas
                     .Where(m => m.idEstudiante == estudiante.idEstudiante && m.SemestreMatricula == semestre)
                     .ToList();
        }
        public string Actualizar(Matricula matricula)
        {
            var matriculaExistente = db.Matriculas.FirstOrDefault(m => m.idMatricula == matricula.idMatricula);

            if (matriculaExistente == null)
            {
                return "Error: La matrícula especificada no existe.";
            }

            var estudianteExiste = db.Estudiantes.Any(e => e.idEstudiante == matricula.idEstudiante);

            if (!estudianteExiste)
            {
                return "Error: El estudiante especificado no existe.";
            }

            if (matricula.NumeroCreditos <= 0 || matricula.ValorCredito <= 0)
            {
                return "Error: Créditos o valor del crédito inválidos.";
            }

            if (string.IsNullOrWhiteSpace(matricula.SemestreMatricula) || string.IsNullOrWhiteSpace(matricula.MateriasMatriculadas))
            {
                return "Error: Información obligatoria incompleta.";
            }

            matriculaExistente.idEstudiante = matricula.idEstudiante;
            matriculaExistente.NumeroCreditos = matricula.NumeroCreditos;
            matriculaExistente.ValorCredito = matricula.ValorCredito;
            matriculaExistente.TotalMatricula = matricula.NumeroCreditos * matricula.ValorCredito;
            matriculaExistente.FechaMatricula = matricula.FechaMatricula;
            matriculaExistente.SemestreMatricula = matricula.SemestreMatricula;
            matriculaExistente.MateriasMatriculadas = matricula.MateriasMatriculadas;

            db.SaveChanges();

            return "Matrícula actualizada correctamente.";
        }
        public string Eliminar(int idMatricula)
        {
            var matricula = db.Matriculas.FirstOrDefault(m => m.idMatricula == idMatricula);

            if (matricula == null)
            {
                return "Error: La matrícula especificada no existe.";
            }

            db.Matriculas.Remove(matricula);
            db.SaveChanges();

            return "Matrícula eliminada correctamente.";
        }
    }
}