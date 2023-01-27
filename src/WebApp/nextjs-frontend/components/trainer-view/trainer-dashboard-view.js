import style from "../trainer-view/trainer-dashboard-view.module.css";
import TrainerOverviewView from "./trainer-overview-view";
import TrainerRightPaneView from "./trainer-right-pane-view";


const TrainerDashboardView = () => {

    return(
        <div className={style.container}>
            <div className={style.header}>
                <h2 style={{marginBottom:"2rem"}}>Dashboard</h2>
            </div>
            <div className={style.overview}>
                <TrainerOverviewView />
                <TrainerRightPaneView />
            </div>
        </div>
    );
}

export default TrainerDashboardView;