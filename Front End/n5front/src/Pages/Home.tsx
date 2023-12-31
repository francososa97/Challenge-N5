import * as React from 'react';
import Avatar from '@mui/material/Avatar';
import CssBaseline from '@mui/material/CssBaseline';
import Box from '@mui/material/Box';
import LockOutlinedIcon from '@mui/icons-material/LockOutlined';
import Typography from '@mui/material/Typography';
import Container from '@mui/material/Container';
import { createTheme, ThemeProvider } from '@mui/material/styles';
import Tablepermissions from "../Components/Tablepermissions.tsx";
import CreatePermission from '../Components/Modals/CreatePermission.tsx';
import Grid from '@mui/material/Grid';
import PermisionContext from '../Context/PermisionContext.tsx';

const defaultTheme = createTheme();

const Home = () => {
  return (
    <ThemeProvider theme={defaultTheme}>
      <Container component="main" maxWidth="lg">
        <CssBaseline />
        <Box
          sx={{
            marginTop: 20,
            display: 'flex',
            flexDirection: 'column',
            alignItems: 'center',
          }}
        >
          <PermisionContext>
            <Avatar sx={{ m: 1, bgcolor: 'secondary.main' }}>
              <LockOutlinedIcon />
            </Avatar>
            <Typography component="h1" variant="h5" >
              Permission
            </Typography>
            <Grid container justifyContent="flex-end">
                <Grid item>
                  <CreatePermission/>
                </Grid>
              </Grid>
            <Tablepermissions/>
          </PermisionContext>
        </Box>
      </Container>
    </ThemeProvider>
  );
}
export default Home;