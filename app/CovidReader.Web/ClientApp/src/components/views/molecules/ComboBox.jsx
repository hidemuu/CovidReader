import React from "react";
import MenuItem from "@material-ui/core/MenuItem";
import FormControl from "@material-ui/core/FormControl";
import Select from "@material-ui/core/Select";
import InputLabel from "@material-ui/core/InputLabel";
import styles from "../../styles/js/styles";

const ComboBox = (props) => {
  const { inputLabel, items, value, defaultValue, onChange } = props;

  return (
    <FormControl className={styles().formControl}>
      <InputLabel>{inputLabel}</InputLabel>
      <Select
        defaultValue={defaultValue}
        value={value}
        onChange={(e) => {
          if (e.target.value !== undefined) {
            onChange(e.target.value);
          }
        }}
      >
        {items.map((item) => (
          <MenuItem value={item.id} key={item.id}>
            {item.value}
          </MenuItem>
        ))}
      </Select>
    </FormControl>
  );
};

export default ComboBox;