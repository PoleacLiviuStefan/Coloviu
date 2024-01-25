import React, { useState, useEffect } from 'react';

export const Colocviu = () => {
    const [profesori, setProfesori] = useState([]);
    const [materii, setMaterii] = useState([]);
    const [asignariMaterii, setAsignariMaterii] = useState([]);
    const [idMaterie, setIdMaterie] = useState("");
    const [idProfesor, setIdProfesor] = useState("");
    useEffect(() => {
        const populateProfesoriData = async () => {
            const response = await fetch('api/profesori');
            const data = await response.json();
            setProfesori(data);
        };

        const populateMateriiData = async () => {
            const response = await fetch('api/materii');
            const data = await response.json();
            setMaterii(data);
        };

        const populateAsignariMateriiData = async () => {
            const response = await fetch('api/asignari');
            const data = await response.json();
            setAsignariMaterii(data);
        };

        populateProfesoriData();
        populateMateriiData();
        populateAsignariMateriiData();
    }, []);
  
    const handleAsignariMateriiData = async () => {
        try {

            const response = await fetch(`api/materii/${idMaterie}`,
                { method: 'PUT' });
            if (response.status.ok)
                alert("A reusit")
        }
        catch (err) {
            alert(err);
        }
            

    };
    const deleteMaterie = async () => {
        try {

            const response = await fetch(`api/materii/${idMaterie}`,
                { method: 'DELETE' });
            if (response.status.ok)
                alert("A reusit")
        }
        catch (err) {
            alert(err);
        }
    }


    const handleAsignariProfesoriData = async () => {
        try {

            const response = await fetch(`api/profesori/${idMaterie}`,
                { method: 'PUT' });
            if (response.status.ok)
                alert("A reusit")
        }
        catch (err) {
            alert(err);
        }


    };
    const deleteProfesor = async () => {
        try {

            const response = await fetch(`api/profesori/${idMaterie}`,
                { method: 'DELETE' });
            if (response.status.ok)
                alert("A reusit")
        }
        catch (err) {
            alert(err);
        }
    }

    return (
        <div>
            <h1>Lista Profesorilor</h1>
            <ul>
                {profesori.map((profesor) => (
                    <li key={profesor.profesorId}>{profesor.nume}</li>
                ))}
            </ul>
            <h1>Lista Materii</h1>
            <ul>
                {materii.map((materie) => (
                    <li key={materie.materieId}>{materie.nume}</li>
                ))}
            </ul>
            <input type="text" value={idMaterie} onChage={(e) => setIdMaterie(e.target.value)} placeholder="introdu id-ul materiei" />
            <input type="text" value={idProfesor} onChage={(e) => setIdProfesor(e.target.value)} placeholder="introdu id-ul materiei" />
            <button onClick={handleAsignariMateriiData}>
            PUT MATERIE
            </button>
            <button onClick={deleteMaterie}>
                DELETE MATERIE
            </button>

            <button onClick={handleAsignariProfesoriData}>
                PUT PROFESOR
            </button>
            <button onClick={deleteProfesor}>
                DELETE PROFESOR
            </button>
        </div>
    );
};
