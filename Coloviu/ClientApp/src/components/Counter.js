import React, { useState,useEffect } from 'react';

export const Counter = () => {
    const [currentCount, setCurrentCount] = useState(0);
    const [notes, setNotes] = useState([]);

    const incrementCounter = () => {
        setCurrentCount(currentCount + 1);
    };

    useEffect(() => {
        const refreshNotes = async () => {
            fetch("/GetNotes")
                .then(response => response.json())
                .then(data => {
                    setNotes(data);
                });
        }

        refreshNotes();
    },[])



    return (
        <div>
            <h1>Counter</h1>
            <p>This is a simple example of a React component.</p>
            <p aria-live="polite">Current count: <strong>{currentCount}</strong></p>
            {notes.map((note, index) => (
                <p key={index}>
                    <b>{note.description}</b>
                </p>
            ))}
            <button className="btn btn-primary" onClick={incrementCounter}>Increment</button>
        </div>
    );
};
