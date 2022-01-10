import React from 'react';
import { Grid } from '@material-ui/core'
import Stepper from '@material-ui/core/Stepper';
import Step from '@material-ui/core/Step';
import StepLabel from '@material-ui/core/StepLabel';
import Button from '@material-ui/core/Button';
import Typography from '@material-ui/core/Typography';

export default class RegisterTemplate extends React.Component {

    //コンストラクタ
    constructor(props) {
        super(props);
        this.state = {
            currentState: 0,
            activeStep: 0,
        };
    }

    render() {
        //const [currentState, setCurrentState] = React.useState({});
        //const value = {
        //    currentState,
        //    setCurrentState
        //};
        //const [activeStep, setActiveStep] = React.useState(0);
        const steps = getSteps();
        const handleNext = () => {
            this.setState({ activeStep: (prevActiveStep) => prevActiveStep + 1 });
        };
        const handleBack = () => {
            this.setState({ activeStep: (prevActiveStep) => prevActiveStep - 1 });
        };
        const handleReset = () => {
            this.setState({ activeStep: 0 });
        };
        return (
            <Grid container>
                <Grid sm={2} />
                <Grid lg={8} sm={8} spacing={10}>
                    <Stepper activeStep={this.state.activeStep} alternativeLabel>
                        {steps.map((label) => (
                            <Step key={label}>
                                <StepLabel>{label}</StepLabel>
                            </Step>
                        ))}
                    </Stepper>
                    <UserInputData.Provider value={this.state.currentState}>
                        {getStepContent(activeStep, handleNext, handleBack)}
                    </UserInputData.Provider>
                    {activeStep === steps.length ? (
                        <div>
                            <Typography >全ステップの表示を完了</Typography>
                            <Button onClick={handleReset}>リセット</Button>
                        </div>
                    ) : (
                        <div>
                            <Typography >{getStepContent(this.state.activeStep)}</Typography>
                            <Button
                                disabled={this.state.activeStep === 0}
                                onClick={handleBack}
                            >
                                戻る
                        </Button>
                            <Button variant="contained" color="primary" onClick={handleNext}>
                                {this.state.activeStep === steps.length - 1 ? '送信' : '次へ'}
                            </Button>
                        </div>
                    )}
                </Grid>
            </Grid>
        )
    }
}
