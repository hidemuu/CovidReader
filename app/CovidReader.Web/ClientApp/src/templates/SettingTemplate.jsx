import React from "react";
import clsx from "clsx";
import { ThemeProvider } from "@material-ui/styles";
import CssBaseline from "@material-ui/core/CssBaseline";
import Drawer from "@material-ui/core/Drawer";
import Box from "@material-ui/core/Box";
import AppBar from "@material-ui/core/AppBar";
import Toolbar from "@material-ui/core/Toolbar";
import List from "@material-ui/core/List";
import Typography from "@material-ui/core/Typography";
import Divider from "@material-ui/core/Divider";
import Container from "@material-ui/core/Container";
import { Link } from "react-router-dom";
import MenuIcon from "@material-ui/icons/Menu";
import ChevronLeftIcon from "@material-ui/icons/ChevronLeft";
import IconButton from "@material-ui/core/IconButton";
import HomeIcon from "@material-ui/icons/Home";
import ShoppingCartIcon from "@material-ui/icons/ShoppingCart";
import ListItem from "@material-ui/core/ListItem";
import ListItemIcon from "@material-ui/core/ListItemIcon";
import ListItemText from "@material-ui/core/ListItemText";
import themes from "../components/styles/js/themes";
import styles from "../components/styles/js/styles";
import Copyright from "../components/views/organisms/Copyright";

//テンプレートデザイン
const SettingTemplate = ({
  children,
  title,
}) => {
  const [open, setOpen] = React.useState(true);
  const handleDrawerOpen = () => {
    setOpen(true);
  };
  const handleDrawerClose = () => {
    setOpen(false);
  };

  return (
    <ThemeProvider theme={themes}>
      <div className={styles().root}>
        <CssBaseline />
        <AppBar
          position="absolute"
                  className={clsx(styles().appBar, open && styles().appBarShift)}
        >
            <Toolbar className={styles().toolbar}>
            <IconButton
              edge="start"
              color="inherit"
              aria-label="open drawer"
              onClick={handleDrawerOpen}
              className={clsx(
                  styles().menuButton,
                  open && styles().menuButtonHidden
              )}
            >
              <MenuIcon />
            </IconButton>
            <Typography
              component="h1"
              variant="h6"
              color="inherit"
              noWrap
              className={styles().title}
            >
              管理画面
            </Typography>
          </Toolbar>
        </AppBar>
        <Drawer
          variant="permanent"
          classes={{
              paper: clsx(styles().drawerPaper, !open && styles().drawerPaperClose),
          }}
          open={open}
        >
            <div className={styles().toolbarIcon}>
            <IconButton onClick={handleDrawerClose}>
              <ChevronLeftIcon />
            </IconButton>
          </div>
          <Divider />
          <List>
              <Link to="/settings" className={styles().link}>
              <ListItem button>
                <ListItemIcon>
                  <HomeIcon />
                </ListItemIcon>
                <ListItemText primary="トップページ" />
              </ListItem>
            </Link>
              <Link to="/settingui" className={styles().link}>
              <ListItem button>
                <ListItemIcon>
                  <ShoppingCartIcon />
                </ListItemIcon>
                <ListItemText primary="サマリーページ" />
              </ListItem>
            </Link>
          </List>
        </Drawer>
        <main className={styles().content}>
          <div className={styles().appBarSpacer} />
          <Container maxWidth="lg" className={styles().container}>
            <Typography
              component="h2"
              variant="h5"
              color="inherit"
              noWrap
              className={styles().pageTitle}
            >
              {title}
            </Typography>
            {children}
            <Box pt={4}>
              <Copyright name="管理画面" />
            </Box>
          </Container>
        </main>
      </div>
    </ThemeProvider>
  );
};

export default SettingTemplate;