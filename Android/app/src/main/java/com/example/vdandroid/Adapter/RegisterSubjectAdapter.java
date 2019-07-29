package com.example.vdandroid.Adapter;

import android.app.Dialog;
import android.content.Context;
import android.support.annotation.NonNull;
import android.support.v7.widget.GridLayoutManager;
import android.support.v7.widget.RecyclerView;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.view.Window;
import android.widget.Button;
import android.widget.TextView;
import android.widget.Toast;

import com.example.vdandroid.Model.RegisterSubjectModel;
import com.example.vdandroid.Presenter.RegistSubjectTask;
import com.example.vdandroid.Presenter.RegistedSubjectTask;
import com.example.vdandroid.Presenter.RegisterSubjectTask;
import com.example.vdandroid.R;
import com.example.vdandroid.View.Interface.IViewRegistSubject;
import com.example.vdandroid.View.Interface.IViewRegistedSubject;
import com.example.vdandroid.View.Interface.IViewRegisterSubject;
import com.example.vdandroid.View.RegisterSubject.TabRegistedSubject;
import com.example.vdandroid.View.RegisterSubject.TabRegisterSubject;

import java.util.HashMap;
import java.util.List;
import java.util.Map;

import static java.security.AccessController.getContext;

public class RegisterSubjectAdapter extends RecyclerView.Adapter<RegisterSubjectAdapter.ViewHolder> {
    private List<RegisterSubjectModel> responseList;
    private int resource;
    private Context mContext;

    public RegisterSubjectAdapter(@NonNull Context context, int resource, List<RegisterSubjectModel> objects) {
        this.responseList = objects;
        this.resource = resource;
        this.mContext = context;
    }

    @NonNull
    @Override
    public RegisterSubjectAdapter.ViewHolder onCreateViewHolder(@NonNull ViewGroup viewGroup, int i) {
        View v = LayoutInflater.from(mContext).inflate(resource,viewGroup,false);
        return new ViewHolder(v);
    }

    @Override
    public void onBindViewHolder(@NonNull ViewHolder viewHolder, final int position) {
        viewHolder.tvSubjectName.setText( responseList.get( position ).getName() );
        viewHolder.tvSubjectCode.setText( responseList.get( position ).getCode() );
        viewHolder.tvSubjectCredit.setText( String.valueOf( responseList.get( position ).getTotal_credits() ) );
        viewHolder.tvSubjectNumber.setText( String.valueOf( responseList.get( position ).getLession_number() ) );
        viewHolder.tvSubjectTeacher.setText( responseList.get( position ).getTeacher_name() );
        viewHolder.btnRegisterSubject.setOnClickListener( new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Map<String,String> map = new HashMap<>();
                map.put( "master_timetable_id", String.valueOf( responseList.get( position ).getMaster_timetable_id() ) );
                if(responseList.get( position ).getStatus() == 3){
                    dialogWarning( map );
                }else{
                    onRegisterSubject( map );
                }
            }
        } );
    }

    @Override
    public int getItemCount() {
        return responseList.size();
    }

    public class ViewHolder extends  RecyclerView.ViewHolder{
        private TextView tvSubjectName;
        private TextView tvSubjectCode;
        private TextView tvSubjectTeacher;
        private TextView tvSubjectNumber;
        private TextView tvSubjectCredit;
        private Button btnRegisterSubject;

        public ViewHolder(@NonNull View itemView) {
            super( itemView );
            this.tvSubjectName = itemView.findViewById( R.id.tvSubjectName );
            this.tvSubjectTeacher = itemView.findViewById( R.id.tvSubjectTeacher );
            this.tvSubjectNumber = itemView.findViewById( R.id.tvSubjectNumber );
            this.tvSubjectCredit = itemView.findViewById( R.id.tvSubjectCredit );
            this.tvSubjectCode = itemView.findViewById( R.id.tvSubjectCode );
            this.btnRegisterSubject = itemView.findViewById( R.id.btnRegisterSubject );
        }
    }

    private void dialogWarning(final Map<String,String> map){
        final Dialog dialog = new Dialog( mContext );
        dialog.requestWindowFeature( Window.FEATURE_NO_TITLE );
        dialog.setCancelable( false );
        dialog.setContentView( R.layout.dialog_warning );

        Button btnOK = dialog.findViewById( R.id.btnOK );
        Button btnCancel = dialog.findViewById( R.id.btnCancel );
        TextView tvWarning = dialog.findViewById( R.id.tvWarning );

        btnOK.setOnClickListener( new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                onRegisterSubject( map );
                dialog.dismiss();
            }
        } );
        btnCancel.setOnClickListener( new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                dialog.dismiss();
            }
        } );

        dialog.show();
    }

    private void onRegisterSubject(Map<String, String > map){
        new RegistSubjectTask( mContext, new IViewRegistSubject() {
            @Override
            public void onGetSuccess() {
                Toast.makeText( mContext, "Success", Toast.LENGTH_SHORT ).show();
                new RegisterSubjectTask( mContext, new IViewRegisterSubject() {
                    @Override
                    public void onGetSuccess() {
                        TabRegisterSubject.adapter = new RegisterSubjectAdapter( mContext, R.layout.item_register_subject, TabRegisterSubject.list);
                        GridLayoutManager gridLayoutManager = new GridLayoutManager(mContext, 1, GridLayoutManager.VERTICAL, false);
                        TabRegisterSubject.lvRegisterSubject.setLayoutManager( gridLayoutManager );
                        TabRegisterSubject.lvRegisterSubject.setAdapter( TabRegisterSubject.adapter );
                        TabRegisterSubject.adapter.notifyDataSetChanged();
                    }

                    @Override
                    public void onGetFail() {

                    }
                } ).execute();

                new RegistedSubjectTask( mContext, new IViewRegistedSubject() {
                    @Override
                    public void onGetSuccess() {
                        TabRegistedSubject.adapter = new RegistedSubjectAdapter( mContext, R.layout.item_registed_subject, TabRegistedSubject.list);
                        GridLayoutManager gridLayoutManager = new GridLayoutManager(mContext, 1, GridLayoutManager.VERTICAL, false);
                        TabRegistedSubject.lvRegistedSubject.setLayoutManager( gridLayoutManager );
                        TabRegistedSubject.lvRegistedSubject.setAdapter( TabRegistedSubject.adapter );
                        TabRegistedSubject.adapter.notifyDataSetChanged();
                    }

                    @Override
                    public void onGetFail() {

                    }
                } ).execute();
            }

            @Override
            public void onGetFail() {
                Toast.makeText( mContext, "Failed", Toast.LENGTH_SHORT ).show();
            }
        }, map ).execute();
    }
}
