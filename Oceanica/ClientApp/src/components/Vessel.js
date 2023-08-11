import React, { useState, useEffect } from "react";
import axios from 'axios';

const Vessel = () => {
    const [vessels, setvessels] = useState();

    const [id, setid] = useState();
    const [name, setname] = useState();
    const [type, settype] = useState();
    const [buildAt, setbuildAt] = useState();

    useEffect(() => {
        (async () => await GetVessels())();
    }, []);

    async function GetVessels() {
        const result = await axios.get("Vessel/GetVessels");
        setvessels(result.data);
        console.log(result.data);
    }

    async function AddVessel(event) {
        event.preventDefault();
        try {
            await axios.post("Vessel/AddVessel", {
                name: name,
                type: type,
                buildat: buildAt,
            });
            alert("Vessel added");

            setid("");
            setname("");
            settype("");
            setbuildAt("");
            GetVessels();
        } catch (error) {
            alert(error);
        }
    }
    return (
        <div className="container">
            <h1>Vessels</h1>
            <div className="row">
                <form>
                    <div className="form-group">
                        <label>Vessel Name</label>
                        <input
                            type="text"
                            className="form-control"
                            id="name"
                            value={name}
                            onChange={(event) => {
                                setname(event.target.value);
                            }}
                        />
                    </div>
                    <div className="form-group">
                        <label>Vessel Type</label>
                        <input
                            type="text"
                            className="form-control"
                            id="type"
                            value={type}
                            onChange={(event) => {
                                settype(event.target.value);
                            }}
                        />
                    </div>
                    <div className="form-group">
                        <label>Vessel BuildAt</label>
                        <input
                            type="date"
                            className="form-control"
                            id="buildat"
                            value={buildAt}
                            onChange={(event) => {
                                setbuildAt(event.target.value);
                            }}
                        />
                    </div>
                    <div>
                        <button className="btn btn-primary" onClick={AddVessel}>
                            Add
                        </button>
                    </div>
                </form>
            </div>
            <div className="row">
                <div className="col-12">
                    <table className="table table-bordered table-stripped">
                        <thead>
                            <tr>
                                <th>Id</th>
                                <th>Name</th>
                                <th>Type</th>
                                <th>BuildAt</th>
                            </tr>
                        </thead>
                        {vessels?.map(function fn(vessel) {
                            return (
                                <tbody>
                                    <tr>
                                        <th scope="row">{vessel.id}</th>
                                        <td>{vessel.name}</td>
                                        <td>{vessel.type}</td>
                                        <td>{vessel.buildAt.substring(0, 10)}</td>
                                    </tr>
                                </tbody>
                            );
                        })}
                    </table>
                </div>
            </div>
        </div>
    );
};

export default Vessel;