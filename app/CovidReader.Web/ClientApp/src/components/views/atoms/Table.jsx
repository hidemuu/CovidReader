import React from "react";
import MaterialTable from 'material-table';

const Table = ({
    title, columns, data
}) => {

        return (
            <div>
                <MaterialTable
                    title={title}
                    columns={columns}
                    data={data}
                    options={{
                        //showTitle: false,
                        paging: false,
                        // search: false,
                        // draggable: false,
                        // filtering: true,
                        maxBodyHeight: 500,
                        headerStyle: {
                            position: 'sticky',
                            top: 0,
                            minWidth: 150,
                        },
                    }}
                />
            </div>
        );
    }

export default Table;