import DefaultLeftPane from "../components/athlete-view/reusable-comps/default-left-pane";
import style from "../styles/athlete-main-page.module.css"
import SettingsView from "../components/settings/settings-view";

const Settings = () => {
    return(
        <div className={style.container}>
            <div style={{borderRight: "1px solid #D0D5DD"}}>
                <DefaultLeftPane />
            </div>
            <SettingsView />
        </div>
    );
}

export default Settings;