import axios from "axios";
import { Space, Table } from "antd";
import 'antd/dist/antd.css';
import { React, useEffect, useState } from "react";
const { Column, ColumnGroup } = Table;
function Categories() {
    const [category, setCategory] = useState([]);
    useEffect(() => {
        axios({
            method: "GET",
            url: "https://localhost:7233/api/category",
            data: null,
        })
            .then((data) => {
                setCategory(data.data);
                console.log(data.data);
            })
            .catch((err) => {
                console.log(err);
            });
    }, []);

    return (
        <div>
            <Table dataSource={category} pagination={{ pageSize: 10 }} key="1">
                <Column title="Id" dataIndex="id" key={category.id} />

                <Column
                    title="Book Name"
                    dataIndex="name"
                    key={category.name}
                />

                {/* <Column title="Gender" dataIndex="gender" key={book.gender} /> */}

                <Column
                    title="Action"
                    key="action"
                    render={(_, record) => (
                        <Space size="middle">
                            <button
                                class="updateButton"
                            // onClick={() => handleUpdate(record.uniqueId)}
                            >
                                Edit {record.firstName}
                            </button>
                            <button
                                class="detailButton"
                            // onClick={() => handleDetail(record.uniqueId)}
                            >
                                Detail
                            </button>
                            <button
                                class="deleteButton"
                            // value={record.uniqueId}
                            // onClick={() => handleDelete(record.uniqueId)}
                            >
                                Delete
                            </button>
                        </Space>
                    )}
                />
            </Table>
        </div>
    );
};

export default Categories;