import "../styles/globals.css";
import "bootstrap/dist/css/bootstrap.css";

import Head from "next/head";
import {SessionProvider} from "next-auth/react";

import {ToastContainer} from "react-toastify";
import "react-toastify/dist/ReactToastify.css";

function MyApp({Component, pageProps: {session, ...pageProps}}) {
    const Layout = Component.layout || (({children}) => <>{children}</>);
    return (
        <>
            <Head>
                <title>BodyGuard</title>
                <meta
                    name='description'
                    content='BodyGuard app meant for all fitness enthusiasts'
                />
                <link rel='icon' href='/favicon.ico'/>
            </Head>
            <SessionProvider session={session}>
                <Layout>
                    <ToastContainer/>
                    <Component {...pageProps} />
                </Layout>
            </SessionProvider>
        </>
    );
}

export default MyApp;
