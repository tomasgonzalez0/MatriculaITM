# MatriculaITM  

**Autores:**  
- Tomas Gonzalez Zapata  
- Juan Jose Aguirre Velazquez  

## Pruebas en Postman

---

### 1. POST - Ingresar matrícula  

**URL:**  
```http
POST http://localhost:<puerto>/api/Matricula/Ingresar
```

**Headers:**  
```
Content-Type: application/json
```

**Body:**  
```json
{
  "idEstudiante": 1,
  "NumeroCreditos": 12,
  "ValorCredito": 95000,
  "TotalMatricula": 1140000,
  "FechaMatricula": "2025-04-21",
  "SemestreMatricula": "2025-1",
  "MateriasMatriculadas": "Matemáticas, Física, Programación"
}
```

---

### 2. GET - Consultar matrícula por documento y semestre  

**URL:**  
```http
GET http://localhost:<puerto>/api/Matricula/ConsultarPorDocumentoYSemestre?documento=123456789&semestre=2025-1
```

---

### 3. PUT - Actualizar matrícula  

**URL:**  
```http
PUT http://localhost:<puerto>/api/Matricula/Actualizar
```

**Body:**  
```json
{
  "idMatricula": 1,
  "idEstudiante": 1,
  "NumeroCreditos": 14,
  "ValorCredito": 95000,
  "TotalMatricula": 1330000,
  "FechaMatricula": "2025-04-21",
  "SemestreMatricula": "2025-1",
  "MateriasMatriculadas": "Matemáticas, Física, Programación, Estadística"
}
```

---

### 4. DELETE - Eliminar matrícula  

**URL:**  
```http
DELETE http://localhost:<puerto>/api/Matricula/Eliminar?id=1
```

---

## Notas

- Reemplazar `<puerto>` con el puerto real que tu aplicación esté usando en Visual Studio o IIS Express (por ejemplo: `44327`).
- Asegúrate de tener un estudiante registrado en la base de datos con `idEstudiante` correspondiente antes de hacer pruebas de matrícula.
