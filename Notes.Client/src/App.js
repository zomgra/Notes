import React from "react";
import NoteCreateForm from "./components/NoteCreateForm";
import NoteUpdateForm from "./components/NoteUpdateForm";

export default function App() {

  const [notes, setNotes] = React.useState([]);
  const [showingCreateNewNoteForm, setShowingCreateNewNoteForm] = React.useState(false)
  const [noteCurrentlyBeingUpdate, setNoteCurrentlyBeingUpdate] = React.useState(null)


  function getNotes() {
    const url = "https://localhost:7189/api/note/"
    fetch(url, {
      method: "GET"
    })
      .then(responce =>
        responce.json())
      .then(json => {
        console.log(json);
        setNotes(json);
      })
      .catch(error => console.error(error));
  }

  function clearNote() {
    setNotes([])
  }

  function deleteNote(deletedNote) {

    if (deletedNote === null) return;

    if (window.confirm("You realy want to delete ".concat(deletedNote.title))) {
      const url = 'https://localhost:7189/api/note/'.concat(deletedNote.noteId)
      fetch(url, {
        method: "DELETE",
      })
        .catch(error => console.error(error));
    }
  }

  return (
    <div className="container">

      {(showingCreateNewNoteForm === false && noteCurrentlyBeingUpdate === null) && (
        <div className="center-text">
          <div className="col">
            <h1>Notes CRUD</h1>
          </div>
          <div className="col">
            <button className="btn btn-outline-info" onClick={getNotes}>Load Notes</button>
            <button className="btn btn-outline-primary mx-4" onClick={() => setShowingCreateNewNoteForm(true)}>Create Notes</button>
          </div>

        </div>
      )}
      <div className="pt-5  d-flex justify-content-center">
        {(notes.length > 0 && showingCreateNewNoteForm === false && noteCurrentlyBeingUpdate === null) && renderTable()}
      </div>
      <div className="d-flex justify-content-center">
        {showingCreateNewNoteForm && <NoteCreateForm onNoteCreated={onNoteCreated} />}
        {noteCurrentlyBeingUpdate !== null && <NoteUpdateForm note={noteCurrentlyBeingUpdate} onNoteUpdated={onNoteUpdated} />}
      </div>
    </div>
  );

  function renderTable() {
    return (
      <div className="w-50 justify-content-center">
        <table className="table table-bordered table-success table-hover">
          <thead className="table table-light">
            <tr>
              <th>Key</th>
              <th>Title</th>
              <th>Description</th>
              <th>Last Operant Time</th>
              <th>Operation</th>
            </tr>
          </thead>

          <tbody>
            {notes.map((note) => (
              <tr key={note.noteId}>
                <th scope="row">{note.noteId}</th>
                <td>{note.title}</td>
                <td>{note.description}</td>
                <td>{note.dateTime}</td>
                <td>
                  <button className="btn btn-success" onClick={() => { setNoteCurrentlyBeingUpdate(note) }}>Update</button>
                  <button className="btn btn-danger px-2" onClick={() => { deleteNote(note) }}>Delete</button>
                </td>
              </tr>
            ))}
          </tbody>
        </table>
        <button onClick={() => setNotes([])}>Clear Table</button>
      </div>
    );
  }
  function onNoteCreated(createdNote) {
    setShowingCreateNewNoteForm(null);
    console.log(noteCurrentlyBeingUpdate);
    if (createdNote === null) return;
    alert('Note successfully created, new title note ', createdNote.title)
    getNotes()
    return;
  }
  function onNoteUpdated(updatedNote) {
    setNoteCurrentlyBeingUpdate(null);
    if (updatedNote === null) {
      return;
    }

    let copyNotes = [...notes];

    const index = copyNotes.findIndex((noteCopyNotes, currentIndex) => {
      if(noteCopyNotes.noteId == updatedNote.noteId){
        return true;
    }});
      
      
      if(index !== -1){
        copyNotes[index] = updatedNote;
      }
      setNotes(copyNotes);
    return;
  }
  function setNewNotes(updatedNote) {
    let notesCopy = [...notes];
    var index = notesCopy.findIndex((notesCopy, currentIndex) => {
      if (notesCopy.noteId === updatedNote.noteId) {
        return true;
      }
    });
    if (index !== -1) {
      notesCopy[index] = updatedNote;
    }
    setNotes(notesCopy);
  }
}