import * as React from "react";
import CircularProgress from "@material-ui/core/CircularProgress";

type Props = {
    
};

export default class Progress extends React.Component<Props> {

    render(): JSX.Element {
        return (
            <CircularProgress color="inherit" />
        );
    }
}