import * as React from "react";
import { Grid } from '@material-ui/core'
import Stepper from '@material-ui/core/Stepper';
import Step from '@material-ui/core/Step';
import StepLabel from '@material-ui/core/StepLabel';
import Button from '@material-ui/core/Button';
import Typography from '@material-ui/core/Typography';

export default class RegisterTemplate extends React.Component<Model.IRegisterTemplate, Field.IRegisterTemplate> {
    
    //コンストラクタ
    constructor(props: Model.IRegisterTemplate) {
        super(props);
        this.state = {
            currentState: 0,
            activeStep: 0,
        };
    }

    render(): JSX.Element {
        return (
            <Grid container>
                <Grid sm={2} />
                <Grid lg={8} sm={8} spacing={10}>
                    <div>
                        <Typography >全ステップの表示を完了</Typography>
                    </div>
                </Grid>
            </Grid>
        )
    }
}