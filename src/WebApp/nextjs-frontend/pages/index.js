import styles from "../styles/Home.module.css";
import Link from "next/link";

export default function Home() {
    return (
        <div className={styles.container}>
            <main className={styles.main}>
                <h1 className={styles.title}>
                    <Link href='/auth/login'>Log in</Link>
                    <br/>
                    <Link href='/auth/signup'>Sign up</Link>
                    <br/>
                    <Link href='/athlete/dashboard'>Go to athlete main page</Link>
                </h1>
            </main>
        </div>
    );
}
