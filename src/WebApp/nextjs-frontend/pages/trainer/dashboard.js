import style from "../styles/athlete-main-page.module.css"
import TrainerDashboardView from "../components/trainer-view/trainer-dashboard/trainer-dashboard-view";
import TrainerLeftPane from "../components/trainer-view/trainer-left-pane";

const TrainerDashboard = () => {
    return(
        <div className={style.container}>
            <div style={{borderRight: "1px solid #D0D5DD", width:"350px"}}>
                <TrainerLeftPane />
            </div>
            <TrainerDashboardView />
        </div>
    );
}

export default TrainerDashboard;