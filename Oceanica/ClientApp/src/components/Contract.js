import React, { useState, useEffect } from "react";
import axios from 'axios';

const Contract = () => {
    const [contracts, setcontracts] = useState();

    const [id, setid] = useState();
    const [startAt, setstartAt] = useState();
    const [endAt, setendAt] = useState();
    const [description, setdescription] = useState();
    const [vesselId, setvesselId] = useState();

    useEffect(() => {
        (async () => await GetContracts())();
    }, []);

    async function GetContracts() {
        const result = await axios.get("Contract/GetContracts");
        setcontracts(result.data);
        console.log(result.data);
    }

    async function AddContract(event) {
        event.preventDefault();
        try {
            await axios.post("Contract/AddContract", {
                startat: startAt,
                endat: endAt,
                description: description,
                vesselId: vesselId,
            });
            alert("Contract added");

            setid("");
            setstartAt("");
            setendAt("");
            setdescription("");
            setvesselId("");
            GetContracts();
        } catch (error) {
            alert(error);
        }
    }
    return (
        <div className="container">
            <h1>Contracts</h1>
            <div className="row">
                <form>
                    <div className="form-group">
                        <label>Contract StartAt</label>
                        <input
                            type="date"
                            className="form-control"
                            id="startAt"
                            value={startAt}
                            onChange={(event) => {
                                setstartAt(event.target.value);
                            }}
                        />
                    </div>
                    <div className="form-group">
                        <label>Contract EndAt</label>
                        <input
                            type="date"
                            className="form-control"
                            id="endAt"
                            value={endAt}
                            onChange={(event) => {
                                setendAt(event.target.value);
                            }}
                        />
                    </div>
                    <div className="form-group">
                        <label>Contract Description</label>
                        <input
                            type="text"
                            className="form-control"
                            id="description"
                            value={description}
                            onChange={(event) => {
                                setdescription(event.target.value);
                            }}
                        />
                    </div>
                    <div className="form-group">
                        <label>Vessel Id</label>
                        <input
                            type="text"
                            className="form-control"
                            id="vesselId"
                            value={vesselId}
                            onChange={(event) => {
                                setvesselId(event.target.value);
                            }}
                        />
                    </div>
                    <div>
                        <button className="btn btn-primary" onClick={AddContract}>
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
                                <th>StartAt</th>
                                <th>EndAt</th>
                                <th>Description</th>
                                <th>VesselId</th>
                            </tr>
                        </thead>
                        {contracts?.map(function fn(contract) {
                            return (
                                <tbody>
                                    <tr>
                                        <th scope="row">{contract.id}</th>
                                        <td>{contract.startAt.substring(0, 10)}</td>
                                        <td>{contract.endAt.substring(0, 10)}</td>
                                        <td>{contract.description}</td>
                                        <td>{contract.vesselId}</td>
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

export default Contract;