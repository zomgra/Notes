import React from "react";
export default function NoteCreateForm(props) {

    const [formData, setFormData] = React.useState()

    const handleSubmit = (e) => {
        e.preventDefault();
        const noteToCreate = {
            title: formData.title,
            description: formData.description,
        }
        const url = "https://localhost:7189/api/note/"

        fetch(url, {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
            },
            body: JSON.stringify(noteToCreate)

        })
            .then(responce =>
                console.log(responce))
            .then(json => {
                console.log(json);
            })
            .catch(error => console.error(error));

        props.onNoteCreated(noteToCreate)
    }
    const handleChange = (e) => {
        setFormData({
            ...formData,
            [e.target.name]: e.target.value,
        });
    };
    return (
        <div className="m-550">
            <form className="">
                <h1>Create new Note</h1>
                <div className="d-flex d-justify-center">
                    <div className="row form border d-inline-flex m-2 p-3">
                        <div className="col-2">
                            <label className="form-label col-sm-6" for="noteTitleInput">Note Title</label>
                        </div>
                        <div className="col-auto">
                            <input className="form-control" id="noteTitleInput" name="title" type="text" placeholder="Title" onChange={handleChange} />
                        </div>
                    </div>
                </div>

                <div className="d-flex d-justify-center">
                    <div className="row d-inline-md-flex border m-2 p-3">
                        <div className="col-auto">
                            <label className="form-label">Note Description</label>
                        </div>
                        <div className="col-auto">
                            <input name="description" className="form-control" type="text" onChange={handleChange} />
                        </div>
                    </div>
                </div>
                <div className="row d-flex justify-content-center">
                    <button className="btn btn-success mx-4 col-4" onClick={handleSubmit}>Submit</button>
                    <button className="btn btn-danger col-4 mx-4" onClick={() => props.onNoteCreated(null)}>Cancel</button>
                </div>

            </form>
        </div>
    );
}