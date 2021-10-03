import { makeStyles } from '@material-ui/core/styles';

export default function getStyle() {
    const useStyles = makeStyles((theme) => ({
        typography: {
          marginTop: theme.spacing(0),
          marginBottom: theme.spacing(0),
        },
        grid: {
          margin: "auto",
        },
        button: {
          marginTop: "auto",
          marginBottom: theme.spacing(5),
          width: "250px",
          height: "200px",
          fontSize: "30px",
          margin: theme.spacing(1),
        },
        backdrop: {
          color: "#fff"
        },
      }));
    return useStyles;
}