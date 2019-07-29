package com.example.vdandroid.Adapter;

import android.content.Context;
import android.support.annotation.NonNull;
import android.support.v7.widget.RecyclerView;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;

import com.example.vdandroid.Model.RegistedSubjectModel;
import com.example.vdandroid.Model.RegisterSubjectModel;
import com.example.vdandroid.R;

import java.util.List;

public class RegistedSubjectAdapter extends RecyclerView.Adapter<RegistedSubjectAdapter.ViewHolder> {
    private List<RegistedSubjectModel> responseList;
    private int resource;
    private Context mContext;

    public RegistedSubjectAdapter(@NonNull Context context, int resource, List<RegistedSubjectModel> objects) {
        this.responseList = objects;
        this.resource = resource;
        this.mContext = context;
    }

    @NonNull
    @Override
    public RegistedSubjectAdapter.ViewHolder onCreateViewHolder(@NonNull ViewGroup viewGroup, int i) {
        View v = LayoutInflater.from(mContext).inflate(resource,viewGroup,false);
        return new RegistedSubjectAdapter.ViewHolder(v);
    }

    @Override
    public void onBindViewHolder(@NonNull ViewHolder viewHolder, int position) {
        viewHolder.tvSubjectName.setText( responseList.get( position ).getName() );
        viewHolder.tvSubjectCode.setText( responseList.get( position ).getCode() );
        viewHolder.tvSubjectCredit.setText( String.valueOf( responseList.get( position ).getTotalCredits() ) );
        viewHolder.tvSubjectNumber.setText( String.valueOf( responseList.get( position ).getLessionNumber() ) );
        viewHolder.tvSubjectTeacher.setText( responseList.get( position ).getTeacherName() );
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

        public ViewHolder(@NonNull View itemView) {
            super( itemView );
            this.tvSubjectName = itemView.findViewById( R.id.tvSubjectName );
            this.tvSubjectTeacher = itemView.findViewById( R.id.tvSubjectTeacher );
            this.tvSubjectNumber = itemView.findViewById( R.id.tvSubjectNumber );
            this.tvSubjectCredit = itemView.findViewById( R.id.tvSubjectCredit );
            this.tvSubjectCode = itemView.findViewById( R.id.tvSubjectCode );
        }
    }
}
