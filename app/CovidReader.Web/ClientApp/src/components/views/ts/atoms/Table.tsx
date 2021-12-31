import * as React from "react";
import MaterialTable from 'material-table';

type Props = {
    title: string;
    columns: object[];
    data: object[];
};

export default class Table extends React.Component<Props> {

    render(): JSX.Element {
        return (
            <div>
                <MaterialTable
                    title={this.props.title}
                    columns={this.props.columns}
                    data={this.props.data}
                    options={{
                        paging: false,
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
}