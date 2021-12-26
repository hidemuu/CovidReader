import React from "react";
import Typography from "@material-ui/core/Typography";

const TypographyLabel = ({ content }) => {
    return (
        <Typography variant="body2" color="textSecondary" align="center">
            {content}
        </Typography>
    );
};
export default TypographyLabel