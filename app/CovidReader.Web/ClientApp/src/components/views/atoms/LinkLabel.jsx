import React from "react";
import { Link } from "react-router-dom";

const LinkLabel = ({ link, name }) => {
    return (
        <Link color="inherit" to={link}>
            {name}
        </Link>
    );
};

export default LinkLabel