import React from "react";
export default function NoteUpdateForm(props){

    const [formData, setFormData] = React.useState() 

    const handleSubmit = (e)=> {
            e.preventDefault();
            const noteToUpdate = {
                noteId: props.note.noteId,
                title: formData.title,
                description: formData.description,
            }
            const url = "https://localhost:7189/api/note/"
   
            fetch(url, {
            method:"PUT",
            headers:{
                "Content-Type":"application/json",
                },
            body: JSON.stringify(noteToUpdate)  
            })
            .catch(error => console.error(error));

            props.onNoteUpdated(noteToUpdate)
    }
    const handleChange = (e)=>{
        setFormData({
            ...formData,
            [e.target.name]: e.target.value,
        });
    };
    return(
        <div>
            <form className="w-100, px-5">
                <h1>Create new Note</h1>

                <div>
                    <label>Note Title</label>
                    <input name="title" type="text" onChange={handleChange}/>
                </div>
                <div>
                    <label>Note Description</label>
                    <input name="description" type="text" onChange={handleChange}/>
                </div>
                <button onClick={handleSubmit}>Submit</button>
                <button onClick={()=> props.onNoteUpdated(null)}>Cancel</button>
                
            </form>
        </div>
    );
}