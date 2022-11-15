import axios from "axios";
import { Space, Table } from "antd";
import 'antd/dist/antd.css';
import { React, useEffect, useState } from "react";
const { Column, ColumnGroup } = Table;
function Books() {
    const [book, setBook] = useState([]);
    useEffect(() => {
        axios({
            method: "GET",
            url: "https://localhost:7233/api/book",
            data: null,
        })
            .then((data) => {
                setBook(data.data);
                console.log(data.data);
            })
            .catch((err) => {
                console.log(err);
            });
    }, []);

    return (
        <div>
            <Table dataSource={book} pagination={{ pageSize: 10 }} key="1">
                <Column title="Id" dataIndex="id" key={book.id} />

                <Column
                    title="Book Name"
                    dataIndex="name"
                    key={book.name}
                />
                <ColumnGroup title="Category">
                    <Column
                        title="Category Id"
                        key={book.category?.id ?? "1"}
                        render={(_, record) => (<p>{record.category?.id ?? ""}</p>)}
                    />
                    <Column
                        title="Category Name"
                        key={book.category?.name ?? "2"}
                        render={(_, record) => (<p>{record.category?.name ?? ""}</p>)}
                    />
                </ColumnGroup>

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

export default Books;